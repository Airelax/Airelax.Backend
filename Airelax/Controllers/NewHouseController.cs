﻿using System.Threading.Tasks;
using Airelax.Application.Houses;
using Airelax.Application.Houses.Dtos.Request;
using Microsoft.AspNetCore.Mvc;

namespace Airelax.Controllers
{
    [ApiController]
    [Route("api/[controller]/new-house")]
    public class NewHouseController : Controller
    {
        private readonly INewHouseService _houseAppService;

        public NewHouseController(INewHouseService houseAppService)
        {
            _houseAppService = houseAppService;
        }

        [HttpPost]
        public async Task<string> CreateHouse(CreateHouseInput input)
        {
            return await _houseAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}/category")]
        public async Task<bool> UpdateHouseCategory(string id, UpdateHouseCategoryInput input)
        {
            return await _houseAppService.UpdateHouseCategory(id, input);
        }

        [HttpPut]
        [Route("{id}/RoomCategory")]
        public async Task<bool> UpdateRoomCategory(string id, UpdateRoomCategoryInput input)
        {
            return await _houseAppService.UpdateRoomCategory(id, input);
        }
        
        [HttpPut]
        [Route("{id}/title")]
        public async Task<bool> UpdateHouseTitle(string id, UpdateHouseTitleInput input)
        {
            return await _houseAppService.UpdateHouseTitle(id, input);
        }

        [HttpPut]
        [Route("{id}/Description")]
        public async Task<bool> UpdateHouseDescription(string id, UpdateHouseDescriptionInput input)
        {
            return await _houseAppService.UpdateHouseDescription(id, input);
        }

        [HttpPut]
        [Route("{id}/facilities")]
        public async Task<bool> UpdateHouseFacilities(string id, UpdateHouseFacilitiesInput input)
        {
            return await _houseAppService.UpdateHouseFacilities(id, input);
        }

        [HttpPut]
        [Route("{id}/customer")]
        public async Task<bool> UpdateCustomerInput(string id, UpdateCustomerInput input)
        {
            return await _houseAppService.UpdateHouseCustomerInput(id, input);
        }

        [HttpPut]
        [Route("{id}/price")]
        public async Task<bool> UpdateHousePrice(string id, UpdateHousePriceInput input)
        {
            return await _houseAppService.UpdateHousePriceInput(id, input);
        }
    }
}