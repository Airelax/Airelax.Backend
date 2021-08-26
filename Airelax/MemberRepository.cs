using Airelax.Domain.Members;
using Airelax.EntityFramework.DbContexts;
using Lazcat.Infrastructure.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airelax
{
    [DependencyInjection(typeof(IMemberRepository))]
    public class MemberRepository : IMemberRepository
    {
        private readonly AirelaxContext _context;
        public MemberRepository(AirelaxContext context)
        {
            _context = context;
        }
        //public IQueryable<Member> GetAll()
        //{
        //    return _context.Set<Member>();
        //}
        public Member GetMember(string memberId)
        {
            return _context.Members.FirstOrDefault(x => x.Id == memberId);
        }
        public MemberTables GetMemberTables(string memberId)
        {
            return (from m in _context.Members
            join mi in _context.MemberLoginInfos on m.Id equals mi.Id
            where m.Id == memberId
            select new MemberTables { Member = m, MemberLoginInfos = mi }).FirstOrDefault();
        }
        //public void Delete(Member member)
        //{
        //    member.IsDeleted = true;
        //    Update(member);
        //}
        public void Update(Member member)
        {
            _context.Update(member);
        }
     
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
