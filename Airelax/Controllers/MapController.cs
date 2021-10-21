using System.Threading.Tasks;
using Airelax.Infrastructure.Map.Abstractions;
using Airelax.Infrastructure.Map.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Airelax.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MapController : Controller
    {
        private readonly IGeocodingService _geocodingService;

        public MapController(IGeocodingService geocodingService)
        {
            _geocodingService = geocodingService;
        }

        public async Task<Coordinate> GetLatLng(string address)
        {
            var geocodingInfo = await _geocodingService.GetGeocodingInfo(address);
            return geocodingInfo.Location;
        }
    }
}