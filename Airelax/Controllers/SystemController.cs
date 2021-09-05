using System;
using Lazcat.Infrastructure.Reflection;
using Microsoft.AspNetCore.Mvc;

namespace Airelax.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SystemController : Controller
    {
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
            return AssemblyVersionHelper.GetBuildTime();
        }
    }
}