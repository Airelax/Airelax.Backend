using Airelax.Application.Orders;
using Airelax.Application.Orders.Request;
using Airelax.Application.Orders.Response;
using Airelax.Infrastructure.ThirdPartyPayment.ECPay;
using Airelax.Infrastructure.ThirdPartyPayment.ECPay.Request;
using Airelax.Infrastructure.ThirdPartyPayment.ECPay.Response;
using Lazcat.Infrastructure.ExceptionHandlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Airelax.Controllers
{

    [Route("api/[controller]")]
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IECPayService _ecPayService;

        public OrdersController(IOrderService orderService, IECPayService ecPayService)
        {
            _orderService = orderService;
            _ecPayService = ecPayService;
        }

        [HttpPost]
        public CreateOrderResponse CreateOrder([FromBody] OrdersInput input)
        {
            if (!ModelState.IsValid) throw ExceptionBuilder.Build(System.Net.HttpStatusCode.BadRequest, "");
            var order = _orderService.CreateOrder(input);
            return order;
        }



        [HttpPost]
        [Route("transaction")]
        public async Task<bool> Transact(CreateTransactionInput createTransactionInput)//傳入paytoken
        {
            var transactResponseData = await _ecPayService.CreateTransaction(createTransactionInput);
            if (transactResponseData == null) return false;
            if (transactResponseData.RtnCode == 1) return true;
            return false;
        }
    }
}