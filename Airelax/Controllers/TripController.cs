using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airelax.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class TripController : Controller
    {
        private readonly ITripService _tripService;
        public TripController (ITripService tripservice)
        {
            _tripService = tripservice;
        }
        [HttpGet]
        
        public async Task<IActionResult> Trip()
        {

            var tripViewModel = await _tripService.GetTripViewModel();

            return View(tripViewModel);
            
        }
    }
}
