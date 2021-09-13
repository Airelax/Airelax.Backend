using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Airelax.Infrastructure.ThirdPartyPayment.ECPay;
using Airelax.Infrastructure.ThirdPartyPayment.ECPay.Response;
using Lazcat.Infrastructure.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace Airelax.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SystemController : Controller
    {
        private readonly IHostEnvironment _environment;
        private readonly IECPayService _ecPayService;

        public SystemController(IHostEnvironment environment, IECPayService ecPayService)
        {
            _environment = environment;
            _ecPayService = ecPayService;
        }


        [HttpGet]
        [Route("version")]
        public string GetVersion()
        {
            return AssemblyVersionHelper.GetVersion();
        }

        [HttpGet]
        [Route("buildTime")]
        public DateTime GetBuildTime()
        {
            return _environment.IsDevelopment()
                ? AssemblyVersionHelper.GetBuildTime()
                : System.IO.File.GetCreationTime(GetType().Assembly.Location);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("pay")]
        public async Task<TokenResponseData> Post()
        {
            var tokenRequestData = await _ecPayService.GetToken();
            return tokenRequestData;
        }

        [HttpPost]
        [Route("tran")]
        public async Task<TransactResponseData> MethodName(string token)
        {
            var transactResponseData = await _ecPayService.CreateTransaction(token);
            return transactResponseData;
        }
        
        [HttpPost]
        [Route("suc")]
        public async Task<string> yee(dynamic d)
        {
            Console.WriteLine(JsonConvert.SerializeObject(d));
            return default; 
        }
    }
}