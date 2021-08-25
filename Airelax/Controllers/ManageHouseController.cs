﻿using System;
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
            var manageInfo = _manageHouseService.GetManageHouseInfo(id);
            return View(manageInfo);
        }

        [HttpPut]
        [Route("{id}/Description")]
        public IActionResult UpdateDescription(string id, [FromBody] HouseDescriptionInput input)
        {
            var description = _manageHouseService.UpdateDescription(id, input);
            return Ok(description);
        }

        [HttpPut]
        [Route("{id}/Title")]
        public IActionResult UpdateTitle(string id, [FromBody] HouseTitleInput input)
        {
            var title = _manageHouseService.UpdateTitle(id, input);
            return Ok(title);
        }

        [HttpPut]
        [Route("{id}/CustomerNumber")]
        public IActionResult UpdateCustomerNumber(string id, [FromBody] CustomerNumberInput input)
        {
            var customerNumber = _manageHouseService.UpdateCustomerNumber(id, input);
            return Ok(customerNumber);
        }

        [HttpPut]
        [Route("{id}/Status")]
        public IActionResult UpdateStatus(string id, [FromBody] HouseStatusInput input)
        {
            var status = _manageHouseService.UpdateStatus(id, input);
            return Ok(status);
        }

        [HttpPut]
        [Route("{id}/Address")]
        public IActionResult UpdateAddress(string id, [FromBody] HouseAddressInput input)
        {
            var address = _manageHouseService.UpdateAddress(id, input);
            return Ok(address);
        }

        [HttpPut]
        [Route("{id}/Location")]
        public IActionResult UpdateLocation(string id, [FromBody] HouseLocationInupt input)
        {
            var location = _manageHouseService.UpdateLocation(id, input);
            return Ok(location);
        }

        [HttpPut]
        [Route("{id}/Category")]
        public IActionResult UpdateCategory(string id, [FromBody] HouseCategoryInput input)
        {
            var category = _manageHouseService.UpdateCategory(id, input);
            return Ok(category);
        }

        [HttpPut]
        [Route("{id}/Price")]
        public IActionResult UpdatePrice(string id, [FromBody] HousePriceInput input)
        {
            var price = _manageHouseService.UpdatePrice(id, input);
            return Ok(price);
        }

        [HttpPut]
        [Route("{id}/Cancel")]
        public IActionResult UpdateCancel(string id, [FromBody] CancelPolicyInput input)
        {
            var cancel = _manageHouseService.UpdateCancel(id, input);
            return Ok(cancel);
        }

        [HttpPut]
        [Route("{id}/RealTime")]
        public IActionResult UpdateRealTime(string id, [FromBody] RealTimeInput input)
        {
            var realTime = _manageHouseService.UpdateRealTime(id, input);
            return Ok(realTime);
        }

        [HttpPut]
        [Route("{id}/CheckTime")]
        public IActionResult UpdateCheckTime(string id, [FromBody] CheckTimeInput input)
        {
            var checkTime = _manageHouseService.UpdateCheckTime(id, input);
            return Ok(checkTime);
        }

        [HttpPut]
        [Route("{id}/Others")]
        public IActionResult UpdateOthers(string id, [FromBody] HouseOtherInput input)
        {
            var others = _manageHouseService.UpdateOthers(id, input);
            return Ok(others);
        }

        [HttpPut]
        [Route("{id}/Rules")]
        public IActionResult UpdateRules(string id, [FromBody] HouseRuleInput input)
        {
            var rules = _manageHouseService.UpdateRules(id, input);
            return Ok(rules);
        }

        [HttpPut]
        [Route("{id}/Facility")]
        public IActionResult UpdateFacility(string id, [FromBody] HouseFacilityInput input)
        {
            var facility = _manageHouseService.UpdateFacility(id, input);
            return Ok(facility);
        }

        //TODO-改Space的PK
        [HttpPost]
        [Route("{id}/Space")]
        public IActionResult UpdateSpace(string id, [FromBody] HouseSpaceInput input)
        {
            var space = _manageHouseService.UpdateSpace(id, input);
            return Ok(space);
        }

        [HttpDelete]
        [Route("{id}/Space")]
        public IActionResult DeleteSpace(string id, [FromBody] HouseSpaceInput input)
        {
            var space = _manageHouseService.DeleteSpace(id, input);
            return Ok(space);
        }
    }
}
