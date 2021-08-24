using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airelax.EntityFramework.DbContexts;
using Microsoft.EntityFrameworkCore;
using Lazcat.Infrastructure.Extensions;
using Lazcat.Infrastructure.ExceptionHandlers;
using Airelax.Domain.Members;

namespace Airelax.Controllers
{
    [Route("[controller]")]
    public class MemberInfoController : Controller
    {
        private readonly AirelaxContext _context;
        public MemberInfoController(AirelaxContext context)
        {
            _context=context ;
        }

        [HttpGet]
        [Route("{memberId}")]
        public IActionResult Index(string memberId)
        {
            //todo 會員照片
            var info =
                (from member in _context.Members
                from contextMemberInfo in _context.MemberInfos.Where(x => x.Id == member.Id).DefaultIfEmpty()
                from contextHouse in _context.Houses.Where(x => x.OwnerId == member.Id).DefaultIfEmpty()
                from contextHouseCategory in _context.HouseCategories.Where(x => x.Id == contextHouse.Id).DefaultIfEmpty()
                from contextComment in _context.Comments.Where(x => x.HouseId == contextHouse.Id).DefaultIfEmpty()
                from contextStar in _context.Stars.Where(x => x.Id == contextComment.Id).DefaultIfEmpty()
                where member.Id == memberId && !member.IsDeleted 
                select new
                {
                    About = contextMemberInfo.About,
                    Location = contextMemberInfo.Location,
                    WorkTime = contextMemberInfo.WorkTime,
                    MemberName = member.Name,
                    RegisterTime = member.RegisterTime,
                    Email = member.Email,
                    HouseTitle = contextHouse.Title,
                    HouseType = contextHouseCategory.HouseType,
                    RoomType = contextHouseCategory.RoomCategory,
                    StarTotal = contextStar,
                    CommentHouseId = contextComment.HouseId,
                    HouseId = contextHouse.Id,
                }).ToList();
           
            
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
                HouseSource = info.Select
                (x =>new MemberInfoHouseDto
                        {                    
                            HouseId = x.HouseId,
                            CommentCount = groupInfo.Count(xc => xc.Key == x.HouseId),
                            HouseType = x.HouseType.ToString(),
                            RoomType = x.RoomType.ToString(),
                            RoomTitle = x.HouseTitle,
                            StarScore = x.StarTotal?.Total
                            //todo cover
                        })
            };
            if (info.IsNullOrEmpty())
            {
                //todo 錯誤畫面
                return Content("錯誤畫面");
            }
            return View(memberInfoViewModel);
        }
        

        [HttpPut]
        [Route("{memberId}")]
        public async Task<bool> UpdateMemberInfo(string memberId,[FromBody] MemberInfoInput input)
        {
          
            var member = (from m in _context.Members
                          from mi in _context.MemberInfos.Where(x=>x.Id == m.Id).DefaultIfEmpty()
                          where m.Id == memberId
                          select new{ Member = m, MemberInfos = mi }).FirstOrDefault();

            if (member == null) 
                throw ExceptionBuilder.Build(System.Net.HttpStatusCode.BadRequest
                    ,$"Member Id:{memberId} does not match any member");//404
            
            if (member?.MemberInfos == null)
            {
                var memberInfo = new MemberInfo(memberId)
                {
                    About = input.About,
                    Location = input.Location,
                    WorkTime = input.WorkTime
                };
                _context.MemberInfos.Add(memberInfo);
            }
            else
            {
                member.MemberInfos.About = input.About;
                member.MemberInfos.Location = input.Location;
                member.MemberInfos.WorkTime = input.WorkTime;
                _context.Update(member.MemberInfos); 
            }
            _context.SaveChanges();

            return true;
        }


    }
}
