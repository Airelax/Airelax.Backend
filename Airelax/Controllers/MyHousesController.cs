using Airelax.Application.Houses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Airelax.Controllers
{
    [Route("[controller]")]
    public class MyHousesController : Controller
    {
        private readonly IMyHousesService _myHousesService;

        public MyHousesController(IMyHousesService myHousesService)
        {
            _myHousesService = myHousesService;
        }

        [HttpGet]
        [Route("{ownerId}")]
        [Authorize]
        public IActionResult MyHousesDetail(string ownerId)
        {
            var myhousesViewModel = _myHousesService.GetMyHouseViewModel(ownerId);
            return View(myhousesViewModel);
        }
    }
}