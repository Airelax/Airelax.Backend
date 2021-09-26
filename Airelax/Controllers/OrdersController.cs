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

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public CreateOrderResponse CreateOrder([FromBody] OrdersInput input)
        {
            if (!ModelState.IsValid)
                throw ExceptionBuilder.Build(System.Net.HttpStatusCode.BadRequest, "");
            var order = _orderService.CreateOrder(input);
            return order;
        }

        [HttpPost]
        [Route("transaction")]
        public async Task<bool> Transact([FromBody] CreateTransactionInput createTransactionInput)
        {
            return await _orderService.Transact(createTransactionInput);
        }
    }
}