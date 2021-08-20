using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airelax.Application.Acount.Dtos.Request;
using Airelax.EntityFramework.DbContexts;

namespace Airelax.Controllers
{
    
    public class AcountController : Controller
    {
        private readonly AirelaxContext _airelaxContext;

        public AcountController(AirelaxContext airelaxContext)
        {
            _airelaxContext = airelaxContext;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterInput input)
        {
            if (ModelState.IsValid)
            {
                var memberEmail = _airelaxContext.Members.FirstOrDefault((m) => m.Email == input.Email);
                if (memberEmail == null)
                {
                    return View();
                }

            }
            return View();
        }
    }

}
