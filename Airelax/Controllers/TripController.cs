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
    public class TripController : Controller
    {
        private readonly ITripService _tripService;
        public TripController (ITripService tripService)
        {
            _tripService = tripService;
        }
        [HttpGet]
        
        public async Task<IActionResult> Trip()
        {

            var tripViewModel = await _tripService.GetTripViewModel();

            return View(tripViewModel);
            
        }
    }
}
