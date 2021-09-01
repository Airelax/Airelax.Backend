using Airelax.EntityFramework.DbContexts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airelax.Controllers
{
    [Route("[controller]")]
    public class OrdersController : Controller
    {
        private readonly AirelaxContext _context;
        public OrdersController(AirelaxContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public
    }
}
