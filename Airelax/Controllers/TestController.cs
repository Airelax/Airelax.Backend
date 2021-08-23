﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using Lazcat.Infrastructure.ExceptionHandlers;
using Lazcat.Infrastructure.Map.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using JsonSerializer = SpanJson.JsonSerializer;

namespace Airelax.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        private readonly IHouseAppService _houseAppService;
        private readonly ILogger _logger;
        private readonly AirelaxContext _context;

        public TestController(IHouseAppService houseAppService, ILogger<TestController> logger, AirelaxContext context)
        {
            _houseAppService = houseAppService;
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<SimpleHouseDto>> t([FromQuery] SearchInput searchInput)
        {
            return await _houseAppService.Search(searchInput);
        }

        [HttpPost]
        [Route("{id}")]
        public async Task<bool> test(string id, HouseDescription input)
        {
            var house = _context.Houses.Include(x => x.HouseDescription).FirstOrDefault(x => x.Id == id);
            if (house == null) throw ExceptionBuilder.Build(HttpStatusCode.BadRequest, $"id: {id} 會員不存在");
            house.HouseDescription = new HouseDescription(house.Id)
            {
                Description = input.Description,
                GuestPermission = input.GuestPermission,
                Others = input.Others,
                SpaceDescription = input.SpaceDescription
            };

            _context.Update(house);
            _context.SaveChanges();
            return true;
        }
        
        
    }
}