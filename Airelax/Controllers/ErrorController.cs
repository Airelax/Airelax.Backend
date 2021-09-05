using Microsoft.AspNetCore.Mvc;

namespace Airelax.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}