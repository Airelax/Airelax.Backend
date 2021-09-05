using System.Linq;
using System.Threading.Tasks;
using Airelax.Application.Houses;
using Airelax.Application.Houses.Dtos.Request;
using Airelax.EntityFramework.DbContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Airelax.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        private readonly AirelaxContext _context;
        private readonly IHouseAppService _houseAppService;
        private readonly ILogger _logger;

        public TestController(IHouseAppService houseAppService, ILogger<TestController> logger, AirelaxContext context)
        {
            _houseAppService = houseAppService;
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task t()
        {
            await _houseAppService.Search(new SearchInput {Location = "taipei"});
        }

        [HttpPost]
        [Route("{id}")]
        public async Task<bool> test(string id)
        {
            var house = _context.Members.FirstOrDefault(x => x.Id == id);
            return true;
        }
    }
}