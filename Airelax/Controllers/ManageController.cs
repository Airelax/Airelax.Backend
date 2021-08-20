using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airelax.Domain.Houses;
using Microsoft.AspNetCore.Mvc;

namespace Airelax.Controllers
{
    public class ManageController : Controller
    {
        public IActionResult Index(dynamic o)
        {
            //    House house = _context.House.first(x => x.id == houseId);
            //    house.HouseCategory = new HouseCategory(id)
            //    {

            //    }

            //    house.HouseCategory.Category = o.Category

            return View();
        }
    }
}
