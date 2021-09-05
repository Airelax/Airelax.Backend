using Airelax.Application.Members.Request;
using Airelax.Domain.Members;
using Airelax.EntityFramework.DbContexts;
using Lazcat.Infrastructure.ExceptionHandlers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airelax.Application.Houses;

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
        public IActionResult MyHousesDetail(string ownerId)
        {
            var myhousesViewModel = _myHousesService.GetMyHouseViewModel(ownerId);
            return View(myhousesViewModel);

        }
    }
}
