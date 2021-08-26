using Airelax.Domain.Members;
using Airelax.EntityFramework.DbContexts;
using Lazcat.Infrastructure.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airelax
{
    [DependencyInjection(typeof(IAccountRepository))]
    public class AccountRepository : IAccountRepository
    {
        private readonly AirelaxContext _ctx;

        public AccountRepository(AirelaxContext airelaxContext)
        {
            _ctx = airelaxContext;
        }

        public MemberLoginInfo GetAccountByEmail(string email)
        {
            return _ctx.MemberLoginInfos.SingleOrDefault((m) => m.Account == email);
        }

        public Member GetEmailByEmail(string email)
        {
            return _ctx.Members.SingleOrDefault((m) => m.Email == email);
        }

        public string GetIdByEmail(string email)
        {
            Member memcomfirm = _ctx.Members.SingleOrDefault((m) => m.Email == email);
            return memcomfirm.Id;
        }

        public MemberLoginInfo GetAccountByAccount(string account)
        {

            return _ctx.MemberLoginInfos.SingleOrDefault((m) => m.Account == account);
        }






        public void Update(Member mem)
        {
            _ctx.Update(mem);
        }

        public void Update(MemberLoginInfo memInfo)
        {
            _ctx.Update(memInfo);
        }

        public void SaveChange()
        {
            _ctx.SaveChanges();
        }

        public void addMem(Member mem)
        {
            _ctx.Members.Add(mem);
        }

        public void addMemInfo(MemberLoginInfo meminfo)
        {
            _ctx.MemberLoginInfos.Add(meminfo);
        }
    }
}
