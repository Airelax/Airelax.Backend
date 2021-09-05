using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airelax.Application.MemberInfos.Response;
using Airelax.Controllers;
using Airelax.Domain.Members;
using Airelax.Domain.RepositoryInterface;
using Airelax.EntityFramework.DbContexts;
using Lazcat.Infrastructure.DependencyInjection;

namespace Airelax.EntityFramework.Repositories
{
    [DependencyInjection(typeof(IMemberInfoRepository))]
    public class MemberInfoRepository : IMemberInfoRepository
    {
        private readonly AirelaxContext _context;

        public MemberInfoRepository(AirelaxContext context)
        {
            _context = context;
        }

        public List<MemberInfoSearchObject> GetMemberInfoSearchObject(string memberId)
        {
            return (from member in _context.Members
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
                    HouseId = contextHouse.Id,
                    Cover = member.Cover,
                    HousePhoto = contextPhoto.Image
                })?.ToList();
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

        public async Task Update(Member member)
        {
            await Task.Run(() => _context.Members.Update(member));
        }

        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }

        public MemberWithMemberInfo GetMemberWithMemberInfo(string memberId)
        {
            return (from m in _context.Members
                from mi in _context.MemberInfos.Where(x => x.Id == m.Id).DefaultIfEmpty()
                where m.Id == memberId
                select new MemberWithMemberInfo {Member = m, MemberInfos = mi}).FirstOrDefault();
        }
    }
}