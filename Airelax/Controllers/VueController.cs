using Microsoft.AspNetCore.Mvc;

namespace Airelax.Controllers
{
    public class VueController : Controller
    {
        [HttpGet("/")]
        [HttpGet("/search")]
        [HttpGet("/room")]
        // GET
        public IActionResult Index()
        {
            return File("/index.html", "text/html");
        }
    }
}