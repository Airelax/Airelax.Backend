using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airelax.EntityFramework.DbContexts;
using Microsoft.EntityFrameworkCore;
using Lazcat.Infrastructure.Extensions;
using Lazcat.Infrastructure.ExceptionHandlers;
using Airelax.Domain.Members;

namespace Airelax.Controllers
{
    [Route("[controller]")]
    public class MemberInfoController : Controller
    {
        private readonly IMemberInfoService _memberInfoService;

        public MemberInfoController(IMemberInfoService memberInfoService)
        {
            _memberInfoService = memberInfoService;
        }


        [HttpGet]
        [Route("{memberId}")]
        public IActionResult Index(string memberId)
        {
            var memberInfoViewModel = _memberInfoService.GetMemberInfoViewModel(memberId);

            if (memberInfoViewModel == null)
            {
                //todo 錯誤畫面
                return Content("錯誤畫面");
            }

            return View(memberInfoViewModel);
        }


        [HttpPut]
        [Route("{memberId}")]
        public async Task<MemberInfoInput> UpdateMemberInfo(string memberId, [FromBody] MemberInfoInput input)
        {
            var aboutMe = _memberInfoService.GetAboutMe(memberId, input);

            return aboutMe;
        }


    }
}
