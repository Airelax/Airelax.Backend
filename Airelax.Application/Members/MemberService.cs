using System;
using System.Net;
using System.Threading.Tasks;
using Airelax.Application.Account;
using Airelax.Application.Members.Dtos.Request;
using Airelax.Application.Members.Dtos.Response;
using Airelax.Domain.Members;
using Airelax.Domain.Members.Defines;
using Airelax.Domain.RepositoryInterface;
using Airelax.Infrastructure.Helpers;
using Lazcat.Infrastructure.DependencyInjection;
using Lazcat.Infrastructure.ExceptionHandlers;
using Microsoft.AspNetCore.Mvc;

namespace Airelax.Application.Members
{
    [DependencyInjection(typeof(IMemberService))]
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IAccountService _accountService;

        public MemberService(IMemberRepository memberRepository, IAccountService accountService)
        {
            _memberRepository = memberRepository;
            _accountService = accountService;
        }

        public MemberViewModel GetMemberViewModel()
        {
            var member = _accountService.GetMember().Result;

            if (member == null)
                return null;

            var memberViewModel = new MemberViewModel
            {
                MemberId = member.Id,
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

        public async Task<bool> EditMember(EditMemberInput input)
        {
            var member = await _accountService.GetMember();

            if (member == null) throw ExceptionBuilder.Build(HttpStatusCode.InternalServerError, "auth member not exist");

            member.Name = input.Name;
            //member.Birthday = input.Birthday;
            member.Gender = (Gender) input.Gender;
            member.Phone = input.Phone;
            member.Country = input.Country;
            member.AddressDetail = input.AddressDetail;

            await _memberRepository.UpdateAsync(member);
            await _memberRepository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> EditLoginAndSecurity(LoginAndSecurityInput input)
        {
            var member = await _accountService.GetMember();
            if (member == null) throw ExceptionBuilder.Build(HttpStatusCode.InternalServerError, "auth member not exist");

            var isPasswordCorrect = CryptographyHelper.VerifyHash(input.OldPassword, member.MemberLoginInfo.Password);
            if (!isPasswordCorrect) throw ExceptionBuilder.Build(HttpStatusCode.Forbidden, "password error");

            var newPassword = CryptographyHelper.Hash(input.Password, out _);
            member.MemberLoginInfo.Password = newPassword;

            await _memberRepository.UpdateAsync(member);
            await _memberRepository.SaveChangesAsync();
            return true;
        }
    }
}