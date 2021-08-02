using System;
using System.Linq;
using Airelax.Domain.Houses;
using Airelax.Domain.Houses.Defines;
using Airelax.EntityFramework.DbContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Airelax.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        private readonly AirelaxContext _context;

        public TestController(AirelaxContext context)
        {
            _context = context;
        }

        [HttpGet]
        public string Get()
        {
            var house = _context.Houses.Include(x=>x.HouseRule).FirstOrDefault(x => x.Id == 2);
            return JsonConvert.SerializeObject(house);
        }
    }
}