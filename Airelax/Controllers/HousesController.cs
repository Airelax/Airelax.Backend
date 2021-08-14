using Airelax.Application.Houses;
using Airelax.Application.Houses.Dtos.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

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
        public async Task<HouseDto> Get(int id)
        {
            return await _houseAppService.GetHouse(id);
        }
        
        // [HttpGet]
        // [Route("Search")]
        // public async Task<ReturnType> MethodName()
        // {
        //     return default;
        // }
    }
}
