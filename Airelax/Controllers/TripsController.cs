using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airelax.Application.Trips;

namespace Airelax.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class TripsController : Controller
    {
        private readonly ITripService _tripService;

        public TripsController(ITripService tripService)
        {
            _tripService = tripService;
        }

        [HttpGet]
        public async Task<IActionResult> Trips()
        {
            var tripViewModel = await _tripService.GetTrips();
            return View(tripViewModel);
        }

        [HttpGet]
        [Route("{id}/detail")]
        public async Task<TripDetail> GetTrip(string id)
        {
            return await _tripService.GetTripDetail(id);
        }
    }
}