using Airelax.Controllers;
using Airelax.Domain.Members;
using Lazcat.Infrastructure.DependencyInjection;
using Lazcat.Infrastructure.ExceptionHandlers;
using Lazcat.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                //todo 會員相片
                HouseSource = info.Select
                (x => new MemberInfoHouseDto
                {
                    HouseId = x.HouseId,
                    CommentCount = groupInfo.Count(xc => xc.Key == x.HouseId),
                    HouseType = x.HouseType.ToString(),
                    RoomType = x.RoomType.ToString(),
                    RoomTitle = x.HouseTitle,
                    StarScore = x.StarTotal?.Total
                    //todo 房屋相片
                })
            };

            return memberInfoViewModel;
        }

        public MemberInfoInput GetAboutMe(string memberId, [FromBody] MemberInfoInput input)
        {
            var member = _memberInfoRepository.GetMemberInfoTables(memberId);

            if (member == null)
                throw ExceptionBuilder.Build(System.Net.HttpStatusCode.BadRequest
                    , $"Member Id:{memberId} does not match any member");//400

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
    }
}
