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
using System.Globalization;
using Newtonsoft.Json;

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
            var house = _ctx.Houses.Include(x => x.HouseDescription)
                .Include(x => x.HouseLocation)
                .Include(x => x.HouseCategory)
                .Include(x => x.HousePrice)
                .Include(x => x.Policy)
                .Include(x => x.HouseRule)
                .Include(x => x.Spaces)
                .FirstOrDefault(x => x.Id == id);

            ManageDto manage = new ManageDto()
            {
                Id = id,
                Title = house.Title,
                //Pictures
                Description = new DescriptionDto()
                {
                    HouseDescription = house.HouseDescription.Description,
                    SpaceDescription = house.HouseDescription.SpaceDescription,
                    GuestPermission = house.HouseDescription.GuestPermission,
                    Others = house.HouseDescription.Others
                },
                Status = (int)house.Status,
                ProvideFacilities = house.ProvideFacilities.Select(s => (int)s).ToList(),
                NotProvideFacilities = house.NotProvideFacilities.Select(s => (int)s).ToList(),
                Address = new AddressDto()
                {
                    City = house.HouseLocation?.City,
                    Country = house.HouseLocation?.Country,
                    Town = house.HouseLocation?.Town,
                    Address = house.HouseLocation?.AddressDetail,
                    ZipCode = house.HouseLocation?.ZipCode,
                    LocationDescription = house.HouseLocation?.LocationDescription,
                    TrafficDescription = house.HouseLocation?.TrafficDescription
                },
                HouseCategory = new HouseCategoryVM()
                {
                    Category = (int)house.HouseCategory.Category,
                    HouseType = (int)house.HouseCategory?.HouseType,
                    RoomCategory = (int)house.HouseCategory?.RoomCategory
                },
                Space = new SpaceDto()
                {
                    CustomerNumber = house.CustomerNumber,
                    //Bathroom
                },
                Origin = Convert.ToString((int)house.HousePrice.PerNight),
                SweetPrice = Convert.ToString((int)house.HousePrice.PerWeekNight),
                //Discount
                //Fee = price.Fee,
                Cancel = (int)house.Policy.CancelPolicy,
                InstanceBooking = house.Policy.CanRealTime,
                CheckinTime = house.Policy.CheckinTime.ToString("t", DateTimeFormatInfo.InvariantInfo),
                CheckoutTime = house.Policy.CheckoutTime.ToString("t", DateTimeFormatInfo.InvariantInfo),
                CashPledge = Convert.ToString((int)house.Policy.CashPledge),
                HouseRule = new HouseRuleDto()
                {
                    //todo make not nullable
                    AllowChild = house.HouseRule.AllowChild,
                    AllowBaby = house.HouseRule.AllowBaby,
                    AllowPet = house.HouseRule.AllowPet,
                    AllowSmoke = house.HouseRule.AllowSmoke,
                    AllowParty = house.HouseRule.AllowParty,
                    Other = house.HouseRule.Other
                }
            };
            return View(manage);
        }

        [HttpPut]
        [Route("{id}/Description")]
        public IActionResult UpdateDescription(string id, [FromBody] HouseDescription input)
        {
            var house = _ctx.Houses.Include(x => x.HouseDescription).FirstOrDefault(x => x.Id == id);
            house.HouseDescription = new HouseDescription(house.Id)
            {
                Description = input.Description,
                GuestPermission = input.GuestPermission,
                Others = input.Others,
                SpaceDescription = input.SpaceDescription
            };
            _ctx.SaveChanges();
            return Ok(input);
        }

        [HttpPut]
        [Route("{id}/Title")]
        public IActionResult UpdateBasic(string id, [FromBody] UpdateHouseTitleInput input)
        {
            var house = _ctx.Houses.FirstOrDefault(x => x.Id == id);
            house.Title = input.Title;
            _ctx.SaveChanges();
            return Ok(input);
        }

        [HttpPut]
        [Route("{id}/CustomerNumber")]
        public IActionResult UpdateCustomerNumber(string id, [FromBody] UpdateCustomerInput input)
        {
            var house = _ctx.Houses.FirstOrDefault(x => x.Id == id);
            house.CustomerNumber = input.CustomerNumber;
            _ctx.SaveChanges();
            return Ok(input);
        }

        [HttpPut]
        [Route("{id}/Status")]
        public IActionResult UpdateStatus(string id, [FromBody] House input)
        {
            var house = _ctx.Houses.FirstOrDefault(x => x.Id == id);
            house.Status = input.Status;
            _ctx.SaveChanges();
            return Ok(input);
        }

        [HttpPut]
        [Route("{id}/Address")]
        public IActionResult UpdateAddress(string id, [FromBody] AddressDto input)
        {
            var house = _ctx.Houses.Include(x => x.HouseLocation).FirstOrDefault(x => x.Id == id);
            house.HouseLocation.Country = input.Country;
            house.HouseLocation.City = input.City;
            house.HouseLocation.Town = input.Town;
            house.HouseLocation.ZipCode = input.ZipCode;
            house.HouseLocation.AddressDetail = input.Address;
            _ctx.SaveChanges();
            return Ok(input);
        }

        [HttpPut]
        [Route("{id}/Location")]
        public IActionResult UpdateLocation(string id, [FromBody] AddressDto input)
        {
            var house = _ctx.Houses.Include(x => x.HouseLocation).FirstOrDefault(x => x.Id == id);
            house.HouseLocation.LocationDescription = input.LocationDescription;
            house.HouseLocation.TrafficDescription = input.TrafficDescription;
            _ctx.SaveChanges();
            return Ok(input);
        }

        [HttpPut]
        [Route("{id}/Category")]
        public IActionResult UpdateHouseType(string id, [FromBody] HouseCategory input)
        {
            var house = _ctx.Houses.Include(x => x.HouseCategory).FirstOrDefault(x => x.Id == id);
            house.HouseCategory.Category = input.Category;
            house.HouseCategory.HouseType = input.HouseType;
            house.HouseCategory.RoomCategory = input.RoomCategory;
            _ctx.SaveChanges();
            return Ok(input);
        }

        [HttpPut]
        [Route("{id}/Price")]
        public IActionResult UpdatePrice(string id, [FromBody] UpdatePrice input)
        {
            var house = _ctx.Houses.Include(x => x.HousePrice).Include(x => x.Policy).FirstOrDefault(x => x.Id == id);
            house.HousePrice.PerNight = input.Origin;
            house.HousePrice.PerWeekNight= input.SweetPrice;
            house.Policy.CashPledge = input.CashPledge;
            _ctx.SaveChanges();
            return Ok(input);
        }

        [HttpPut]
        [Route("{id}/Cancel")]
        public IActionResult UpdateCancel(string id, [FromBody] CancelPolicy input)
        {
            var house = _ctx.Houses.Include(x => x.Policy).FirstOrDefault(x => x.Id == id);
            house.Policy.CancelPolicy = input;
            _ctx.SaveChanges();
            return Ok(input);
        }

        [HttpPut]
        [Route("{id}/RealTime")]
        public IActionResult UpdateRealTime(string id, [FromBody] bool input)
        {
            var house = _ctx.Houses.Include(x => x.Policy).FirstOrDefault(x => x.Id == id);
            house.Policy.CanRealTime = input;
            _ctx.SaveChanges();
            return Ok(input);
        }

        [HttpPut]
        [Route("{id}/CheckTime")]
        public IActionResult UpdateCheckTime(string id, [FromBody] UpdateTime input)
        {
            var house = _ctx.Houses.Include(x => x.Policy).FirstOrDefault(x => x.Id == id);
            house.Policy.CheckinTime = Convert.ToDateTime(input.CheckinTime);
            house.Policy.CheckoutTime = Convert.ToDateTime(input.CheckoutTime);
            _ctx.SaveChanges();
            return Ok(input);
        }

        [HttpPut]
        [Route("{id}/Others")]
        public IActionResult UpdateOthers(string id, [FromBody] string input)
        {
            var house = _ctx.Houses.Include(x => x.HouseRule).FirstOrDefault(x => x.Id == id);
            house.HouseRule.Other = input;
            _ctx.SaveChanges();
            return Ok(input);
        }

        [HttpPut]
        [Route("{id}/Rules")]
        public IActionResult UpdateRules(string id, [FromBody] UpdateAllow input)
        {
            var house = _ctx.Houses.Include(x => x.HouseRule).FirstOrDefault(x => x.Id == id);
            house.HouseRule.AllowChild = input.AllowChild;
            house.HouseRule.AllowBaby = input.AllowBaby;
            house.HouseRule.AllowPet = input.AllowPet;
            house.HouseRule.AllowSmoke = input.AllowSmoke;
            house.HouseRule.AllowParty = input.AllowParty;
            _ctx.SaveChanges();
            return Ok(input);
        }

        [HttpPut]
        [Route("{id}/Facility")]
        public IActionResult UpdateFacility(string id, [FromBody] UpdateFacility input)
        {
            var house = _ctx.Houses.FirstOrDefault(x => x.Id == id);
            house.ProvideFacilities = input.ProvideFacilities;
            house.NotProvideFacilities = input.NotProvideFacilities;
            _ctx.SaveChanges();
            return Ok(input);
        }

        //[HttpPut]
        //[Route("{id}/Space")]
        //public IActionResult UpdateSpace(string id, [FromBody] Space input)
        //{
        //    var house = _ctx.Houses.Include(x => x.Spaces).FirstOrDefault(x => x.Id == id);
        //    house.Spaces = new Space(id)
        //    {

        //    };
        //    _ctx.SaveChanges();
        //    return Ok(input);
        //}
    }
}
