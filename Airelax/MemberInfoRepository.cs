using Airelax.Domain.Members;
using Airelax.EntityFramework.DbContexts;
using Lazcat.Infrastructure.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Airelax.Controllers;

namespace Airelax
{
    [DependencyInjection(typeof(IMemberInfoRepository))]
    public class MemberInfoRepository : IMemberInfoRepository
    {
        private readonly AirelaxContext _context;

        public MemberInfoRepository(AirelaxContext context)
        {
            _context = context;
        }

        public IEnumerable<MemberInfoSearchObject> GetMemberInfoSearchObject(string memberId)
        {
            return
                (
                    from member in _context.Members
                    from contextMemberInfo in _context.MemberInfos.Where(x => x.Id == member.Id).DefaultIfEmpty()
                    from contextHouse in _context.Houses.Where(x => x.OwnerId == member.Id).DefaultIfEmpty()
                    from contextPhoto in _context.Photos.Where(x => x.HouseId == contextHouse.Id).DefaultIfEmpty()
                    from contextHouseCategory in _context.HouseCategories.Where(x => x.Id == contextHouse.Id).DefaultIfEmpty()
                    from contextComment in _context.Comments.Where(x => x.HouseId == contextHouse.Id).DefaultIfEmpty()
                    from contextStar in _context.Stars.Where(x => x.Id == contextComment.Id).DefaultIfEmpty()
                    where member.Id == memberId && !member.IsDeleted
                    select new MemberInfoSearchObject
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
                        HouseId = contextHouse.Id
                        //todo 會員相片 跟 房屋相片
                    }
                )?.ToList();
        }

        public void Add(MemberInfo memberInfo)
        {
            _context.MemberInfos.Add(memberInfo);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(MemberInfo input)
        {
            _context.Update(input);
        }

        public MemberInfoTables GetMemberInfoTables(string memberId)
        {
            return (from m in _context.Members
                    from mi in _context.MemberInfos.Where(x => x.Id == m.Id).DefaultIfEmpty()
                    where m.Id == memberId
                    select new MemberInfoTables { Member = m, MemberInfos = mi }).FirstOrDefault();
        }
    }
}