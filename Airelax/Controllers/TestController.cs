using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airelax.Application;
using Airelax.Application.Houses.Dtos.Response;
using Airelax.Domain.Houses;
using Airelax.Domain.Houses.Defines;
using Airelax.Domain.Houses.Price;
using Airelax.Domain.Members;
using Airelax.Domain.Members.Defines;
using Airelax.Domain.RepositoryInterface;
using Airelax.EntityFramework.DbContexts;
using AutoMapper;
using Lazcat.Infrastructure.Map.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using JsonSerializer = SpanJson.JsonSerializer;

namespace Airelax.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        private readonly AirelaxContext _context;
        private readonly IMapper _mapper;
        private readonly IGeocodingService _geocodingService;


        public TestController(AirelaxContext context, IMapper mapper, IGeocodingService geocodingService)
        {
            _context = context;
            _mapper = mapper;
            _geocodingService = geocodingService;
        }

        [HttpGet]
        public async Task<string> Get()
        {
            return JsonConvert.SerializeObject(await _geocodingService.GetGeocodingInfo("嘉義縣六腳鄉工廠村129-4號"));
            // var house = _context.Houses.FirstOrDefault(x => x.Id == "H75a54f44ff");
            //
            // return System.Text.Json.JsonSerializer.Serialize(house.ProvideFacilities);

            //_context.SaveChanges();

            // var member = new Member()
            // {
            //     City = "c", Birthday = DateTime.Now, Country = "con", Email = "adfjakd", Gender = Gender.Man, Name = "asdf", Town = "adfa", Phone = "adfa", RegisterTime = DateTime.Now,
            //     AddressDetail = "as"
            // };
            // _context.Members.Add(member);
            // _context.SaveChanges();
            //
            // var house = new House()
            // {
            //     OwnerId = member.Id,
            //     CreateState = CreateState.Building,
            //     CreateTime = DateTime.Now, CustomerNumber = 1,
            //     Status = HouseStatus.Off,
            //     LastModifyTime = DateTime.Now, Title = "123",
            // };
            //
            // house.HouseCategory = new HouseCategory(house.Id);
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
            //_context.SaveChanges();

            //var house = _context.Houses.Include(x=>x.HouseRule).FirstOrDefault(x => x.Id == 2);
            return default;
            //return JsonConvert.SerializeObject(_mapper.Map<House,HouseDto>(house));
        }

        // [HttpGet]
        // [Route("id")]
        // public async Task<HouseDto> Get(string id)
        // {
        //     id = "H75a54f44ff";
        //     var house = await _houseRepository.GetAsync(x => x.Id == id);
        //     //Console.WriteLine(JsonConvert.SerializeObject(house.HouseDescription));
        //     var houseDto = _mapper.Map<House, HouseDto>(house);
        //     Console.WriteLine(JsonSerializer.Generic.Utf16.Serialize(houseDto));
        //     houseDto.Description = _mapper.Map<HouseDescription, DescriptionDto>(house.HouseDescription);
        //     return houseDto;
        // }
    }
}