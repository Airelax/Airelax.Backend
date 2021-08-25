using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Airelax.Application.Houses.Dtos.Request.ManageHouse;

namespace Airelax.Controllers
{
    [Route("[controller]")]
    public class ManageHouseController : Controller
    {
        private readonly IManageHouseService _manageHouseService;
        public ManageHouseController(IManageHouseService manageHouseService)
        {
            _manageHouseService = manageHouseService;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Index(string id)
        {
            return View(_manageHouseService.GetManageHouseInfo(id));
        }

        [HttpPut]
        [Route("{id}/Description")]
        public IActionResult UpdateDescription(string id, [FromBody] HouseDescriptionInput input)
        {
            return Ok(_manageHouseService.UpdateDescription(id, input));
        }

        [HttpPut]
        [Route("{id}/Title")]
        public IActionResult UpdateTitle(string id, [FromBody] HouseTitleInput input)
        {
            return Ok(_manageHouseService.UpdateTitle(id, input));
        }

        [HttpPut]
        [Route("{id}/CustomerNumber")]
        public IActionResult UpdateCustomerNumber(string id, [FromBody] CustomerNumberInput input)
        {
            return Ok(_manageHouseService.UpdateCustomerNumber(id, input));
        }

        [HttpPut]
        [Route("{id}/Status")]
        public IActionResult UpdateStatus(string id, [FromBody] HouseStatusInput input)
        {
            return Ok(_manageHouseService.UpdateStatus(id, input));
        }

        [HttpPut]
        [Route("{id}/Address")]
        public IActionResult UpdateAddress(string id, [FromBody] HouseAddressInput input)
        {
            return Ok(_manageHouseService.UpdateAddress(id, input));
        }

        [HttpPut]
        [Route("{id}/Location")]
        public IActionResult UpdateLocation(string id, [FromBody] HouseLocationInupt input)
        {
            return Ok(_manageHouseService.UpdateLocation(id, input));
        }

        [HttpPut]
        [Route("{id}/Category")]
        public IActionResult UpdateCategory(string id, [FromBody] HouseCategoryInput input)
        {
            return Ok(_manageHouseService.UpdateCategory(id, input));
        }

        [HttpPut]
        [Route("{id}/Price")]
        public IActionResult UpdatePrice(string id, [FromBody] HousePriceInput input)
        {
            return Ok(_manageHouseService.UpdatePrice(id, input));
        }

        [HttpPut]
        [Route("{id}/Cancel")]
        public IActionResult UpdateCancel(string id, [FromBody] CancelPolicyInput input)
        {
            return Ok(_manageHouseService.UpdateCancel(id, input));
        }

        [HttpPut]
        [Route("{id}/RealTime")]
        public IActionResult UpdateRealTime(string id, [FromBody] RealTimeInput input)
        {
            return Ok(_manageHouseService.UpdateRealTime(id, input));
        }

        [HttpPut]
        [Route("{id}/CheckTime")]
        public IActionResult UpdateCheckTime(string id, [FromBody] CheckTimeInput input)
        {
            return Ok(_manageHouseService.UpdateCheckTime(id, input));
        }

        [HttpPut]
        [Route("{id}/Others")]
        public IActionResult UpdateOthers(string id, [FromBody] HouseOtherInput input)
        {
            return Ok(_manageHouseService.UpdateOthers(id, input));
        }

        [HttpPut]
        [Route("{id}/Rules")]
        public IActionResult UpdateRules(string id, [FromBody] HouseRuleInput input)
        {
            return Ok(_manageHouseService.UpdateRules(id, input));
        }

        [HttpPut]
        [Route("{id}/Facility")]
        public IActionResult UpdateFacility(string id, [FromBody] HouseFacilityInput input)
        {
            return Ok(_manageHouseService.UpdateFacility(id, input));
        }

        //[HttpPut]
        //[Route("{id}/Space")]
        //public IActionResult UpdateSpace(string id, [FromBody] Space input)
        //{
        //    var x = from h in _context.Houses
        //            from s in _context.Spaces.Where(x => x.HouseId == h.Id).DefaultIfEmpty()
        //            from b in _context.BedroomDetails.Where(x => x.SpaceId == s.Id).DefaultIfEmpty()
        //            where h.Id == "H005ba2165b"
        //            select new { s = s, b = b };

        //    var y = x.ToList();

        //    _ctx.SaveChanges();
        //    return Ok(input);
        //}
    }
}
