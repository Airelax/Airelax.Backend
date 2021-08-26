using Airelax.Application.Members.Request;
using Airelax.Domain.Members;
using Lazcat.Infrastructure.DependencyInjection;
using Lazcat.Infrastructure.ExceptionHandlers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airelax
{
    [DependencyInjection(typeof(IMemberService))]
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }
        public MemberViewModel GetMemberViewModel(string memberId)
        {
            var member = _memberRepository.GetMember(memberId);

            if (member == null)

                return null;

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
            return memberViewModel;
        }
        public Member JudgeMember(string memberId)
        {
            var member = _memberRepository.GetMember(memberId);

            if (member == null)

                return null;

            return member;
        }
        public async Task<bool> EditMember(string memberId, [FromBody] EditMemberInput input)
        {
            var member = _memberRepository.GetMember(memberId);

            if (member == null) throw ExceptionBuilder.Build(System.Net.HttpStatusCode.BadRequest, $"Member Id {memberId} does not match any member");

            member.Name = input.Name;
            //member.Birthday = input.Birthday;
            //member.Gender = input.Gender;
            member.Phone = input.Phone;
            member.Country = input.Country;
            member.AddressDetail = input.AddressDetail;


            _memberRepository.Update(member);
            _memberRepository.SaveChanges();

            return true;

        }
        public async Task<bool> EditLoginAndSecurity(string memberId, [FromBody] LoginAndSecurityInput input)
        {
            var member = _memberRepository.GetMemberTables(memberId);
            if (member == null) throw ExceptionBuilder.Build(System.Net.HttpStatusCode.BadRequest, $"Member Id {memberId} does not match any member");

            
            member.MemberLoginInfos.Password = input.Password;
            //todo密碼加密
            member.Member.MemberLoginInfo = member.MemberLoginInfos;

            _memberRepository.Update(member.Member);
            _memberRepository.SaveChanges();
            return true;
        }

    }
}
