using System.Threading.Tasks;
using Airelax.Application.Members;
using Airelax.Application.Members.Dtos.Request;
using Microsoft.AspNetCore.Mvc;

namespace Airelax.Controllers
{
    [Route("[controller]")]
    public class MemberController : Controller
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpGet]
        [Route("{memberId}/detail")]
        public IActionResult EditMember(string memberId)
        {
            var memberViewModel = _memberService.GetMemberViewModel(memberId);
            return View(memberViewModel);
        }

        [HttpGet]
        [Route("{memberId}/security")]
        public IActionResult LoginAndSecurity(string memberId)
        {
            var member = _memberService.JudgeMember(memberId);

            if (member == null)
                // todo 倒到錯誤畫面
                return View();

            return View();
        }

        [HttpPut]
        [Route("{memberId}/detail")]
        public async Task<bool> UpdateMember(string memberId, [FromBody] EditMemberInput input)
        {
            return await _memberService.EditMember(memberId, input);
        }

        [HttpPut]
        [Route("{memberId}/security")]
        public async Task<bool> UpdateLoginAndSecurity(string memberId, [FromBody] LoginAndSecurityInput input)
        {
            return await _memberService.EditLoginAndSecurity(memberId, input);
        }
    }
}