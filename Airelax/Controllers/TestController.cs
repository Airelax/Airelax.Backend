using System;
using System.Linq;
using Airelax.Domain.Houses;
using Airelax.Domain.Houses.Defines;
using Airelax.EntityFramework.DbContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var house = _context.Houses.Include(x => x.HouseCategory).FirstOrDefault(x => x.Id == 2);
            _context.Houses.Add(new House() {Title = "123", Status = HouseStatus.Off, CreateState = CreateState.Building, CreateTime = DateTime.Now, CustomerNumber = 4, LastModifyTime = DateTime.Now, OwnerId = 1,});
            _context.SaveChanges();
            return house.HouseCategory.HouseType.ToString();
        }
    }
}