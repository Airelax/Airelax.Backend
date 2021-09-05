﻿using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Airelax.Application.MemberInfos;
using Airelax.Application.MemberInfos.Request;

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
        public Task<MemberInfoInput> UpdateMemberInfo(string memberId, [FromBody] MemberInfoInput input)
        {
            var aboutMe = _memberInfoService.GetAboutMe(memberId, input);
            return Task.FromResult(aboutMe);
        }

        [HttpGet]
        [Route("{memberId}/edit-photo")]
        public IActionResult EditPhoto(string memberId)
        {
            ViewBag.MemberId = memberId;
            return View();
        }

        [HttpPut]
        [Route("{memberId}/edit-photo")]
        public async Task<string> EditPhoto(string memberId, [FromBody] EditPhotoInput input)
        {
            return await _memberInfoService.UpdateCover(memberId, input);
        }
    }
}