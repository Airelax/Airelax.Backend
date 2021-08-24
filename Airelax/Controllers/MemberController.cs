using Airelax.Application.Members.Request;
using Airelax.Domain.Members;
using Airelax.EntityFramework.DbContexts;
using Lazcat.Infrastructure.ExceptionHandlers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airelax.Controllers
{
    [Route("[controller]")]
    public class MemberController : Controller
    {
        private readonly AirelaxContext _context;
        public MemberController(AirelaxContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("{memberId}/detail")]
        public IActionResult EditMember(string memberId)
        {
            var member = _context.Members.FirstOrDefault(x => x.Id == memberId);

            if (member == null)
                //todo 倒到錯誤畫面
                return View();

            var memberViewModel = new MemberViewModel()
            {
                MemberId = memberId,
                Name = member.Name,
                Gender = member.Gender,
                Birthday = member.Birthday.ToString("yyyy-MM-dd"),
                Email = member.Email,
                Phone = member.Phone,
                Country = member.Country,
                //todo Zipcode
                AddressDetail = member.AddressDetail
            };
            return View(memberViewModel);
        }
        [HttpGet]
        [Route("{memberId}/security")]
        public IActionResult LoginAndSecurity(string memberId)
        {
            var member = _context.Members.FirstOrDefault(x => x.Id == memberId);

            if (member == null)
                // todo 倒到錯誤畫面
                return View();
            
            return View();
        }
           
        [HttpPut]
        [Route("{memberId}/detail")]
        public async Task<bool> EditMember(string memberId,EditMemberInput input) 
        {
            var member = _context.Members.FirstOrDefault(x => x.Id == memberId);

            if (member == null) throw ExceptionBuilder.Build(System.Net.HttpStatusCode.BadRequest, $"Member Id {memberId} does not match any member");

            member.Name = input.Name;
            member.Birthday = input.Birthday;
            member.Gender = input.Gender;
            member.Phone = input.Phone;
            member.Country = input.Country;
            member.AddressDetail = input.AddressDetail;


            _context.Update(member);
            _context.SaveChanges();
            return true;
        }
        [HttpPut]
        [Route("{memberId}/security")]
        public async Task<bool> LoginAndSecurity(string memberId,[FromBody] LoginAndSecurityInput input)
        {
            var member = (from m in _context.Members
                          join mi in _context.MemberLoginInfos on m.Id equals mi.Id
                          where m.Id == memberId
                          select new { Member = m, MemberLoginInfos = mi }).FirstOrDefault();
            if (member == null) throw ExceptionBuilder.Build(System.Net.HttpStatusCode.BadRequest, $"Member Id {memberId} does not match any member");


            member.MemberLoginInfos.Password = input.Password;
            //todo密碼加密

            _context.Update(member);
            _context.SaveChanges();
            return true;
        }
    }
}
