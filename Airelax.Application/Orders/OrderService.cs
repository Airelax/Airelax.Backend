using System;
using System.Linq;
using System.Threading.Tasks;
using Airelax.Application.Account;
using Airelax.Application.Orders.Request;
using Airelax.Application.Orders.Response;
using Airelax.Domain.Orders;
using Airelax.Domain.Orders.Define;
using Airelax.Domain.RepositoryInterface;
using Airelax.Infrastructure.Helpers;
using Airelax.Infrastructure.ThirdPartyPayment.ECPay;
using Airelax.Infrastructure.ThirdPartyPayment.ECPay.Request;
using Lazcat.Infrastructure.DependencyInjection;
using Lazcat.Infrastructure.ExceptionHandlers;
using SpanJson;

namespace Airelax.Application.Orders
{
    [DependencyInjection(typeof(IOrderService))]
    public class OrderService : IOrderService
    {
        private readonly IHouseRepository _houseRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IAccountService _accountService;
        private readonly IECPayService _eCPayService;

        public OrderService(IHouseRepository houseRepository, IOrderRepository orderRepository, IAccountService accountService, IECPayService eCPayService)
        {
            _houseRepository = houseRepository;
            _orderRepository = orderRepository;
            _accountService = accountService;
            _eCPayService = eCPayService;
        }

        public CreateOrderResponse CreateOrder(OrdersInput input)
        {
            //取與house有關聯全表
            var house = _houseRepository.GetAsync(x => x.Id == input.HouseId).Result;
            //house.HousePrice  
            //取與order有關聯全表
            if (house == null) throw ExceptionBuilder.Build(System.Net.HttpStatusCode.BadRequest,"");

            // 更改房子的可預訂時間
            var dateRange = DateTimeHelper.GetDateRange(input.StartDate, input.EndDate).ToList();
            if (house.ReservationDates.Intersect(dateRange).Any()) throw ExceptionBuilder.Build(System.Net.HttpStatusCode.BadRequest, "");
            house.ReservationDates.AddRange(dateRange);

            var member = _accountService.GetMember().Result;

            var order = new Order(member.Id, house.Id);
            //轉換
            //HousePrice裡面的計算總價丟進OrderPriceDetail裡面的總價
            //把前端開始日期與結束日期放進OrderDetails
            //把前端人數丟進OrderDetail
            order.OrderDetail = new OrderDetail(order.Id)
            {
                Adult = input.Adult,
                Child = input.Child,
                Baby = input.Baby,
                StartDate = input.StartDate,
                EndDate = input.EndDate
            };
            order.OrderPriceDetail = new OrderPriceDetail(order.Id)
            {
                Total = house.HousePrice.CalculateTotalPrice(input.StartDate, input.EndDate)
            };

            var createTokenInput=new CreateTokenInput
            {
                MerchantTradeNo = order.Id,
                TotalAmount = (int)order.OrderPriceDetail.Total,
                TradeDesc = $"{house.Title} 的住宿 共{(order.OrderDetail.EndDate - order.OrderDetail.StartDate).TotalDays} 晚",
                ItemName = $"{house.Title} 的住宿 共{(order.OrderDetail.EndDate - order.OrderDetail.StartDate).TotalDays} 晚",
                Name = member.Name,
                Email = member.Email,
                MerchantMemberId = member.Id
            };
            
            var tokenData=_eCPayService.GetToken(createTokenInput).Result;
            var createOrderResponse = new CreateOrderResponse
            {
                Token = tokenData.Token,
                OrderId = order.Id
            };

            Console.WriteLine(JsonSerializer.Generic.Utf16.Serialize(tokenData));
            _houseRepository.UpdateAsync(house);
            _orderRepository.Add(order);
            _orderRepository.SaveChanges();
            return createOrderResponse;
        }

        public async Task<bool> Transact(CreateTransactionInput input)
        {
            var transactResponseData = await _eCPayService.CreateTransaction(input);
            if (transactResponseData == null) return false;

            var order =await _orderRepository.GetOrderAsync(x=>x.Id==input.MerchantTradeNo);
            order.State = OrderState.Finish;
            _orderRepository.Update(order);
            _orderRepository.SaveChanges();
            return true;
        }
    }
}