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

        [HttpGet]
        [Route("{id}")]     
        public async Task<HouseDto> Get(string id)
        {
            return await _houseAppService.GetHouse(id);
        }
        
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

        public async Task<bool> UpdateHouseCategory(string id, UpdateHouseCategoryInput input ) 
        {
            return await _houseAppService.UpdateHouseCategory(id,input);
        }

        [HttpPut]
        [Route("house/{id}/category")]
   
        public async Task<bool> UpdateHouseCategoryRoomStyle(string id, UpdateHouseCategoryRoomStyleInput input)
        {
            return await _houseAppService.UpdateHouseCategoryRoomStyle(id, input);
        }

        [HttpPut]
        [Route("house/{id}/title")]
        public async Task<bool> UpdateHouseTitle(string id, UpdateHouseTitle input)
        {
            return await _houseAppService.UpdateHouseTitle(id, input);
        }
        public async Task<bool>UpdateHouseDescription(string id ,UpdateHouseDescription input)
        {
            return await _houseAppService.UpdateHousrDescription(id, input);
        }

    }
}
