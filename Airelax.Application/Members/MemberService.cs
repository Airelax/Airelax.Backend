using System;
using System.Threading.Tasks;
using Airelax.Application.Members.Dtos.Request;
using Airelax.Application.Members.Dtos.Response;
using Airelax.Application.Members.Request;
using Airelax.Domain.Members;
using Airelax.Domain.Members.Defines;
using Airelax.Domain.RepositoryInterface;
using Lazcat.Infrastructure.DependencyInjection;
using Lazcat.Infrastructure.ExceptionHandlers;
using Microsoft.AspNetCore.Mvc;

namespace Airelax.Application.Members
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
            var member = _memberRepository.GetAsync(x => x.Id == memberId).Result;

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
                AddressDetail = member.AddressDetail
            };
            return memberViewModel;
        }

        public Member JudgeMember(string memberId)
        {
            var member = _memberRepository.GetAsync(x => x.Id == memberId).Result;

            return member;
        }

        public async Task<bool> EditMember(string memberId, [FromBody] EditMemberInput input)
        {
            var member = await _memberRepository.GetAsync(x => x.Id == memberId);

            if (member == null) throw ExceptionBuilder.Build(System.Net.HttpStatusCode.BadRequest, $"Member Id {memberId} does not match any member");

            member.Name = input.Name;
            member.Birthday = DateTime.Parse(input.Birthday);
            member.Gender = (Gender) input.Gender;
            member.Phone = input.Phone;
            member.Country = input.Country;
            member.AddressDetail = input.AddressDetail;


            await _memberRepository.UpdateAsync(member);
            await _memberRepository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> EditLoginAndSecurity(string memberId, [FromBody] LoginAndSecurityInput input)
        {
            var member = await _memberRepository.GetAsync(x => x.Id == memberId);
            if (member == null) throw ExceptionBuilder.Build(System.Net.HttpStatusCode.BadRequest, $"Member Id {memberId} does not match any member");

            member.MemberLoginInfo.Password = input.Password;
            //todo 密碼加密， 驗證舊密碼

            await _memberRepository.UpdateAsync(member);
            await _memberRepository.SaveChangesAsync();
            return true;
        }
    }
}