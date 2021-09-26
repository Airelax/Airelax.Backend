using System.Threading.Tasks;
using Airelax.Application.MemberInfos;
using Airelax.Application.MemberInfos.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Airelax.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class MemberInfoController : Controller
    {
        private readonly IMemberInfoService _memberInfoService;

        public MemberInfoController(IMemberInfoService memberInfoService)
        {
            _memberInfoService = memberInfoService;
        }

        [HttpGet]
        [Route("~")]
        [Route("{memberId?}")]
        public IActionResult Index(string memberId)
        {
            var memberInfoViewModel = _memberInfoService.GetMemberInfoViewModel(memberId);

            if (memberInfoViewModel == null)
                return RedirectToAction("Index", "Error");

            return View(memberInfoViewModel);
        }


        [HttpPut]
        [Route("{memberId}")]
        public async Task<UpdateMemberInfoInput> UpdateMemberInfo(string memberId, [FromBody] UpdateMemberInfoInput input)
        {
            var aboutMe = await _memberInfoService.UpdateMemberInfo(input);
            return aboutMe;
        }

        [HttpGet]
        [Route("edit-photo")]
        public IActionResult EditPhoto()
        {
            return View();
        }

        [HttpPut]
        [Route("edit-photo")]
        public async Task<string> EditPhoto([FromBody] EditPhotoInput input)
        {
            return await _memberInfoService.UpdateCover(input);
        }
    }
}