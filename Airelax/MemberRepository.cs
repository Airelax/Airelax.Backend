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
        public IQueryable<Member> GetAll()
        {
            return _context.Set<Member>();
        }
        public Member Get(string memberId)
        {
            return _context.Members.FirstOrDefault(x => x.Id == memberId);
        }
        public void Delete(Member member)
        {
            member.IsDeleted = true;
            Update(member);
        }
        public void Update(Member member)
        {
            _context.Update(member);
        }
        public void SaveChange()
        {
            _context.SaveChanges();
        }
    }
}
