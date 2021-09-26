using Microsoft.AspNetCore.Mvc;

namespace Airelax.Controllers
{
    public class VueController : Controller
    {
        [HttpGet("/")]
        [HttpGet("/room")]
        [HttpGet("/new-house")]
        [HttpGet("/become-host")]
        [HttpGet("/become-host/new-house")]
        [HttpGet("/wishList")]
        [HttpGet("/wishLists")]
        // [HttpGet("/become-host/{houseId?}/new-house")]
        // GET
        public IActionResult Index()
        {
            return File("/index.html", "text/html");
        }

        [HttpGet("/search")]
        public IActionResult Search(dynamic parameters)
        {
            return File("/index.html", "text/html");
        }

        [HttpGet("/become-host/category")]
        [HttpGet("/become-host/{id?}/category")]
        [HttpGet("/become-host/{id}/type")]
        [HttpGet("/become-host/{id}/room")]
        [HttpGet("/become-host/{id}/location")]
        [HttpGet("/become-host/{id}/facilities")]
        [HttpGet("/become-host/{id}/price")]
        [HttpGet("/become-host/{id}/description")]
        [HttpGet("/become-host/{id}/title")]
        [HttpGet("/subscribe/{id}")]
        [HttpGet("/message")]
        [HttpGet("/room/{id}")]
        [HttpGet("/wishLists/{id}")]
        public IActionResult BecomeHost(string id)
        {
            return File("/index.html", "text/html");
        }
    }
}