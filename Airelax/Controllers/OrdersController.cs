using Airelax.Application.Orders;
using Airelax.Application.Orders.Request;
using Microsoft.AspNetCore.Mvc;

namespace Airelax.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public bool CreateOrder([FromBody] OrdersInput input)
        {
            var order = _orderService.CreateOrder(input);
            return ModelState.IsValid && order;
        }
    }
}