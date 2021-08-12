using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airelax.Application;
using Airelax.Application.Houses;
using Airelax.Application.Houses.Dtos.Request;
using Airelax.Application.Houses.Dtos.Response;
using Airelax.Domain.Houses;
using Airelax.Domain.Houses.Defines;
using Airelax.Domain.Houses.Price;
using Airelax.Domain.Members;
using Airelax.Domain.Members.Defines;
using Airelax.Domain.RepositoryInterface;
using Airelax.EntityFramework.DbContexts;
using AutoMapper;
using Lazcat.Infrastructure.Map.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using JsonSerializer = SpanJson.JsonSerializer;

namespace Airelax.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        private readonly IHouseAppService _houseAppService;

        public TestController(IHouseAppService houseAppService)
        {
            _houseAppService = houseAppService;
        }

        [HttpGet]
        public async Task t([FromQuery] SearchInput searchInput)
        {
            await _houseAppService.Search(searchInput);
        }
    }
}