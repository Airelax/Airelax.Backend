using Airelax.Application.Orders.Request;
using Airelax.Domain.Orders;
using Airelax.Domain.RepositoryInterface;
using Lazcat.Infrastructure.DependencyInjection;

namespace Airelax.Application.Orders
{
    [DependencyInjection(typeof(IOrderService))]
    public class OrderService : IOrderService
    {
        private readonly IHouseRepository _houseRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderService(IHouseRepository houseRepository, IOrderRepository orderRepository)
        {
            _houseRepository = houseRepository;
            _orderRepository = orderRepository;
        }

        public bool CreateOrder(OrdersInput input)
        {
            //取與house有關聯全表
            var house = _houseRepository.GetAsync(x => x.Id == input.HouseId).Result;
            //house.HousePrice  
            //取與order有關聯全表
            if (house == null) return false;

            var order = new Order(input.CustomerId, house.Id);
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
                PricePerNight = house.HousePrice.CalculateTotalPrice(input.StartDate, input.EndDate)
            };

            _orderRepository.Add(order);
            _orderRepository.SaveChanges();
            return true;
        }
    }
}