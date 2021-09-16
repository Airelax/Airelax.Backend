using System.Threading.Tasks;
using Airelax.Application.Members;
using Airelax.Application.Members.Dtos.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Airelax.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class MemberController : Controller
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("detail")]
        public IActionResult EditMember()
        {
            var memberViewModel = _memberService.GetMemberViewModel();
            return View(memberViewModel);
        }

        [HttpGet]
        [Route("security")]
        public IActionResult LoginAndSecurity()
        {
            return View();
        }

        [HttpGet]
        [Route("today")]
        public IActionResult Today()
        {
            return View();
        }

        [HttpPut]
        [Route("detail")]
        public async Task<bool> UpdateMember([FromBody]EditMemberInput input)
        {
            return await _memberService.EditMember(input);
        }

        [HttpPut]
        [Route("{memberId}/security")]
        public async Task<bool> UpdateLoginAndSecurity(string memberId, [FromBody] LoginAndSecurityInput input)
        {
            return await _memberService.EditLoginAndSecurity(input);
        }
    }
}