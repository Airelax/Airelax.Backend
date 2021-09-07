using System;
using System.IO;
using System.Reflection;
using Lazcat.Infrastructure.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace Airelax.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SystemController : Controller
    {
        private readonly IHostEnvironment _environment;

        public SystemController(IHostEnvironment environment)
        {
            _environment = environment;
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
            return _environment.IsDevelopment() ? AssemblyVersionHelper.GetBuildTime() 
                : System.IO.File.GetCreationTime(GetType().Assembly.Location);
        }
        
    }
}