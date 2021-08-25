using Airelax.Domain.Members;
using Airelax.EntityFramework.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airelax
{
    public class MemberInfoRepository
    {
        private readonly AirelaxContext _context;
        public MemberInfoRepository(AirelaxContext context)
        {
            _context = context;
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
    }
}
