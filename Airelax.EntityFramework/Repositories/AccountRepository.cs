using System.Linq;
using Airelax.Domain.Members;
using Airelax.Domain.RepositoryInterface;
using Airelax.EntityFramework.DbContexts;
using Lazcat.Infrastructure.DependencyInjection;

namespace Airelax.EntityFramework.Repositories
{
    [DependencyInjection(typeof(IAccountRepository))]
    public class AccountRepository : IAccountRepository
    {
        private readonly AirelaxContext _ctx;

        public AccountRepository(AirelaxContext airelaxContext)
        {
            _ctx = airelaxContext;
        }

        public MemberLoginInfo GetMemberInfoByAccount(string account)
        {
            return _ctx.MemberLoginInfos.SingleOrDefault(m => m.Account == account);
        }

        public Member GetMemByAccount(string account)
        {
            return _ctx.Members.SingleOrDefault(m => m.Email == account);
        }

        public Member GetMemByEmail(string email)
        {
            return _ctx.Members.SingleOrDefault(m => m.Email == email);
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

        public void AddMem(Member mem)
        {
            _ctx.Members.Add(mem);
        }

        public void AddMemInfo(MemberLoginInfo memInfo)
        {
            _ctx.MemberLoginInfos.Add(memInfo);
        }

        public void UpdateToken(string id, string token)
        {
            var memberLoginInfo = _ctx.MemberLoginInfos.SingleOrDefault(m => m.Id == id);
            memberLoginInfo.Token = token;
            SaveChange();
        }
    }
}