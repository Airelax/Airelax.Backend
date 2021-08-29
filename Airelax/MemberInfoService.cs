using Airelax.Controllers;
using Airelax.Domain.Members;
using Lazcat.Infrastructure.DependencyInjection;
using Lazcat.Infrastructure.ExceptionHandlers;
using Lazcat.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Airelax.Application.MemberInfo.Request;

namespace Airelax
{
    [DependencyInjection(typeof(IMemberInfoService))]
    public class MemberInfoService : IMemberInfoService
    {
        private readonly IMemberInfoRepository _memberInfoRepository;

        public MemberInfoService(IMemberInfoRepository memberInfoRepository)
        {
            _memberInfoRepository = memberInfoRepository;
        }

        public MemberInfoViewModel GetMemberInfoViewModel(string memberId)
        {
            var info = _memberInfoRepository.GetMemberInfoSearchObject(memberId);
            if (info.IsNullOrEmpty()) return null;

            var groupInfo = info.GroupBy(x => x.HouseId);
            var memberInfoViewModel = new MemberInfoViewModel()
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

        public MemberInfoInput GetAboutMe(string memberId, [FromBody] MemberInfoInput input)
        {
            var member = GetMemberWithMemberInfo(memberId);

            if (member?.MemberInfos == null)
            {
                var memberInfo = new MemberInfo(memberId)
                {
                    About = input.About,
                    Location = input.Location,
                    WorkTime = input.WorkTime
                };
                _memberInfoRepository.Add(memberInfo);
            }
            else
            {
                member.MemberInfos.About = input.About;
                member.MemberInfos.Location = input.Location;
                member.MemberInfos.WorkTime = input.WorkTime;
                _memberInfoRepository.Update(member.MemberInfos);
            }

            _memberInfoRepository.SaveChanges();
            return input;
        }

        public async Task<string> UpdateCover(string memberId, EditPhotoInput input)
        {
            var memberWithMemberInfo = GetMemberWithMemberInfo(memberId);
            memberWithMemberInfo.Member.Cover = input.PhotoUrl;
            await _memberInfoRepository.Update(memberWithMemberInfo.Member);
            await _memberInfoRepository.SaveChangeAsync();
            return memberWithMemberInfo.Member.Cover;
        }

        private MemberWithMemberInfo GetMemberWithMemberInfo(string memberId)
        {
            var member = _memberInfoRepository.GetMemberWithMemberInfo(memberId);

            if (member?.Member == null)
                throw ExceptionBuilder.Build(System.Net.HttpStatusCode.BadRequest
                    , $"Member Id:{memberId} does not match any member"); //400
            return member;
        }
    }
}