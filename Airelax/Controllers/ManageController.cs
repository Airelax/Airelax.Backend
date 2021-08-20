using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airelax.Domain.Houses;
using Microsoft.AspNetCore.Mvc;
using Airelax.EntityFramework.DbContexts;
using Airelax.Application.Houses.Dtos.Response;
using Airelax.Application.Houses.Dtos.Request;
using Airelax.Domain.Houses.Defines;
using Airelax.Domain.Houses.Price;
using Microsoft.EntityFrameworkCore;

namespace Airelax.Controllers
{
    [Route("[controller]")]
    public class ManageController : Controller
    {
        private readonly AirelaxContext _ctx;
        public ManageController(AirelaxContext context)
        {
            _ctx = context;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Index(string id)
        {
            //var hou = from h in _ctx.Houses 
            //          join hd in _ctx.HouseDescriptions on h.Id equals hd.Id
            //          where h.Id == "1"
            //          select new { house = h, hd = hd };

            //_ctx.Houses.Include(x => x.HouseDescription).FirstOrDefault(x => x.Id == "1");


            House house = _ctx.Houses.FirstOrDefault(x => x.Id == id);
            HouseDescription descript = _ctx.HouseDescriptions.FirstOrDefault(x => x.Id == id);
            HouseLocation location = _ctx.HouseLocations.FirstOrDefault(x => x.Id == id);
            HouseCategory category = _ctx.HouseCategories.FirstOrDefault(x => x.Id == id);
            HousePrice price = _ctx.HousePrices.FirstOrDefault(x => x.Id == id);
            Policy cancelPolicy = _ctx.Policies.FirstOrDefault(x => x.Id == id);
            HouseRule houseRule = _ctx.HouseRules.FirstOrDefault(x => x.Id == id);

            ManageDto manage = new ManageDto()
            {
                Title = house.Title,
                //Pictures
                Description = new DescriptionDto()
                {
                    HouseDescription = descript.Description,
                    SpaceDescription = descript.SpaceDescription,
                    GuestPermission = descript.GuestPermission,
                    Others = descript.Others
                },
                Status = house.Status,
                ProvideFacilities = house.ProvideFacilities,
                NotProvideFacilities = house.NotProvideFacilities,
                Address = new AddressDto()
                {
                    City = location.City,
                    Country = location.Country,
                    Town = location.Town,
                    Address = location.AddressDetail,
                    ZipCode = location.ZipCode,
                    LocationDescription = location.LocationDescription,
                    TrafficDescription = location.TrafficDescription
                },
                HouseCategory = new HouseCategoryVM()
                {
                    Category = category.Category,
                    HouseType = (HouseType)category.HouseType,
                    RoomCategory = (RoomCategory)category.RoomCategory
                },
                Space = new SpaceDto()
                {
                    CustomerNumber = house.CustomerNumber,
                    //Bathroom
                },
                Price = new PriceDto()
                {
                    Origin = price.PerNight,
                    SweetPrice = price.PerWeekNight,
                    //Discount = new DiscountDto()
                    //{
                    //    Month = price.
                    //}
                },
                //Fee = price.Fee,
                Cancel = cancelPolicy.CancelPolicy,
                InstanceBooking = cancelPolicy.CanRealTime,
                HouseRule = new HouseRuleDto()
                {
                    CheckinTime = cancelPolicy.CheckinTime,
                    CheckoutTime = cancelPolicy.CheckoutTime,
                    //todo make not nullable
                    CashPledge = (decimal)cancelPolicy.CashPledge,
                    AllowChild = houseRule.AllowChild,
                    AllowBaby = houseRule.AllowBaby,
                    AllowPet = houseRule.AllowPet,
                    AllowSmoke = houseRule.AllowSmoke,
                    AllowParty = houseRule.AllowParty,
                    Other = houseRule.Other
                }
            };
            return View(manage);
        }
    }
}
