using Airelax.Application.Houses;
using Airelax.Application.Houses.Dtos.Request;
using Airelax.Application.Houses.Dtos.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airelax.Controllers
{
    [ApiController]
    [Route(template: "api/[controller]")]
    public class HousesController : Controller
    {
        private readonly IHouseAppService _houseAppService;

        public HousesController(IHouseAppService houseAppService)
        {
            _houseAppService = houseAppService;
        }

        //[HttpGet]
        //[Route("{id}")]     
        //public async Task<HouseDto> Get(string id)
        //{
        //    return await _houseAppService.GetHouse(id);
        //}

        // [HttpGet]
        // [Route("Search")]
        // public async Task<ReturnType> MethodName()
        // {
        //     return default;
        // }

        [HttpPost]
        [Route("house")]
        public async Task<string> CreateHouse(CreateHouseInput input)
        {
            return await _houseAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("house/{id}/category")]

        public async Task<bool> UpdateHouseCategory(string id, UpdateHouseCategoryInput input)
        {
            return await _houseAppService.UpdateHouseCategory(id, input);
        }

        [HttpPut]
        [Route("house/{id}/RoomCategory")]

        public async Task<bool> UpdateRoomCategory(string id, UpdateRoomCategoryInput input)
        {
            return await _houseAppService.UpdateRoomCategory(id, input);
        }

        [HttpPut]
        [Route("house/{id}/title")]
        public async Task<bool> UpdateHouseTitle(string id, UpdateHouseTitleInput input)
        {
            return await _houseAppService.UpdateHouseTitle(id, input);
        }
        [HttpPut]
        [Route("house/{id}/Description")]
        public async Task<bool> UpdateHouseDescription(string id, UpdateHouseDescriptionInput input)
        {
            return await _houseAppService.UpdateHouseDescription(id, input);
        }
        [HttpPut]
        [Route("house/{id}/facilities")]
        public async Task<bool> UpdateHouseFacilities (string id,UpdateHouseFacilitiesInput input)
        {
            return await _houseAppService.UpdateHouseFacilities(id, input);
        }
        [HttpPut]
        [Route("house/{id}/customer")]
        public async Task<bool> UpdateCustomerInput(string id, UpdateCustomerInput input)
        {
            return await _houseAppService.UpdateHouseCustomerInput(id, input);
        }
        [HttpPut]
        [Route("house/{id}/price")]
        public async Task<bool> UpdateHousePrice (string id,UpdateHousePriceInput input)
        {
            return await _houseAppService.UpdateHousePriceInput(id, input);
        }
    }
}
