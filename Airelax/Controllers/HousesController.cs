using System.Threading.Tasks;
using Airelax.Application.Houses;
using Airelax.Application.Houses.Dtos.Request;
using Airelax.Application.Houses.Dtos.Response;
using Microsoft.AspNetCore.Mvc;

namespace Airelax.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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

        [HttpGet]
        [Route("Search")]
        public async Task<SearchHousesResponse> Search([FromQuery] SearchInput input)
        {
            return await _houseAppService.Search(input);
        }
    }
}