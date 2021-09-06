using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Airelax.Application.Account;
using Airelax.Application.MemberInfos.Request;
using Airelax.Application.MemberInfos.Response;
using Airelax.Domain.Members;
using Airelax.Domain.RepositoryInterface;
using Lazcat.Infrastructure.DependencyInjection;
using Lazcat.Infrastructure.ExceptionHandlers;
using Lazcat.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Airelax.Application.MemberInfos
{
    [DependencyInjection(typeof(IMemberInfoService))]
    public class MemberInfoService : IMemberInfoService
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IAccountService _accountService;

        public MemberInfoService(IMemberRepository memberRepository, IAccountService accountService)
        {
            _memberRepository = memberRepository;
            _accountService = accountService;
        }

        public MemberInfoViewModel GetMemberInfoViewModel(string memberId)
        {
            var authMemberId = _accountService.GetAuthMemberId();
            var isOwner = memberId == authMemberId;
            if (memberId.IsNullOrEmpty())
            {
                memberId = authMemberId;
                isOwner = true;
            }

            var info = _memberRepository.GetMemberInfoSearchObject(memberId);
            if (info.IsNullOrEmpty()) return null;

            var groupInfo = info.GroupBy(x => x.HouseId);
            var memberInfoViewModel = new MemberInfoViewModel
            {
                MemberId = memberId,
                About = info.First().About,
                Location = info.First().Location,
                WorkTime = info.First().WorkTime,
                MemberName = info.First().MemberName,
                RegisterTime = info.First().RegisterTime.ToString("yyyy"),
                Email = info.First().Email,
                MemberImg = info.First().Cover,
                HouseSource = info.Select
                (x => new MemberInfoHouseDto
                {
                    HouseId = x.HouseId,
                    CommentCount = groupInfo.Count(xc => xc.Key == x.HouseId),
                    HouseType = x.HouseType.ToString(),
                    RoomType = x.RoomType.ToString(),
                    RoomTitle = x.HouseTitle,
                    StarScore = x.StarTotal?.Total,
                    Cover = x.HousePhoto
                }),
                IsOwner = isOwner
            };

            return memberInfoViewModel;
        }

        public async Task<UpdateMemberInfoInput> UpdateMemberInfo(UpdateMemberInfoInput input)
        {
            var member = await _accountService.GetMember();

            var memberInfo = new MemberInfo(member.Id)
            {
                About = input.About,
                Location = input.Location,
                WorkTime = input.WorkTime
            };

            member.MemberInfo = memberInfo;

            await UpdateMember(member);
            return input;
        }

        public async Task<string> UpdateCover( EditPhotoInput input)
        {
            var member = await _accountService.GetMember();
            member.Cover = input.PhotoUrl;
            await UpdateMember(member);
            return member.Cover;
        }

        private async Task UpdateMember(Member member)
        {
            await _memberRepository.UpdateAsync(member);
            await _memberRepository.SaveChangesAsync();
        }
    }
}