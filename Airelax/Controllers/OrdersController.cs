using Airelax.EntityFramework.DbContexts;
using Lazcat.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airelax.Application.Orders;
using Airelax.Application.Orders.Request;

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
            if (!ModelState.IsValid) return false;
            return order;
        }
    }
}