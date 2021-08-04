using System;
using System.Collections.Generic;
using System.Linq;
using Airelax.Application.Houses.Dtos.Response;
using Airelax.Domain.Houses;
using Airelax.Domain.Houses.Defines;
using Airelax.Domain.Houses.Price;
using Airelax.Domain.Members;
using Airelax.Domain.Members.Defines;
using Airelax.EntityFramework.DbContexts;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public TestController(AirelaxContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public string Get()
        {
            // var member = new Member(){City = "c", Birthday = DateTime.Now, Country = "con", Email = "adfjakd", Gender = Gender.Man, Name = "asdf", Town = "adfa", Phone = "adfa", RegisterTime = DateTime.Now, AddressDetail = "as" };
            // _context.Members.Add(member);
            // _context.SaveChanges();
            
            // var house = new House(){OwnerId = 1,CreateState = CreateState.Building, CreateTime = DateTime.Now, CustomerNumber = 1, Status = HouseStatus.Off, LastModifyTime = DateTime.Now,Title = "123"};
            // _context.Houses.Add(house);
            // _context.SaveChanges();
            
            // var housePrice = new HousePrice()
            // {
            //     Id = 2, PerNight = 1000, Discount = new Discount()
            //     {
            //         Month = 12, Week = 20, OtherDiscount = new List<DiscountDetail>
            //         {
            //             new DiscountDetail()
            //             {
            //                 Days = 5,
            //                 Discount = 3
            //             }
            //         }
            //     },
            //     Fee = new Fee()
            //     {
            //         CleanFee = 500,
            //         ServiceFee = 100,
            //         TaxFee = 50
            //     },
            // };
            // _context.HousePrices.Add(housePrice);
            // _context.SaveChanges();

            //var house = _context.Houses.Include(x=>x.HouseRule).FirstOrDefault(x => x.Id == 2);
            return default;
            //return JsonConvert.SerializeObject(_mapper.Map<House,HouseDto>(house));
        }
    }
}