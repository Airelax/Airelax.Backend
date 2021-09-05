using System.Linq;
using System.Net;
using System.Threading.Tasks;
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

        public MemberInfoService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public MemberInfoViewModel GetMemberInfoViewModel(string memberId)
        {
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
                })
            };

            return memberInfoViewModel;
        }

        public async Task<UpdateMemberInfoInput> UpdateMemberInfo(string memberId, UpdateMemberInfoInput input)
        {
            var member = await GetMember(memberId);

            var memberInfo = new MemberInfo(memberId)
            {
                About = input.About,
                Location = input.Location,
                WorkTime = input.WorkTime
            };

            member.MemberInfo = memberInfo;

            await UpdateMember(member);
            return input;
        }

        public async Task<string> UpdateCover(string memberId, EditPhotoInput input)
        {
            var member = await GetMember(memberId);
            member.Cover = input.PhotoUrl;
            await UpdateMember(member);
            return member.Cover;
        }

        private async Task UpdateMember(Member member)
        {
            await _memberRepository.UpdateAsync(member);
            await _memberRepository.SaveChangesAsync();
        }

        private async Task<Member> GetMember(string memberId)
        {
            var member = await _memberRepository.GetAsync(x => x.Id == memberId);
            if (member == null)
                throw ExceptionBuilder.Build(HttpStatusCode.BadRequest, $"Member Id:{memberId} does not match any member");
            return member;
        }
    }
}