using System.Collections.Generic;
using System.Threading.Tasks;
using Airelax.Controllers;
using Airelax.Domain.Members;
using Airelax.Domain.Members.Defines;

namespace Airelax.Domain.RepositoryInterface
{
    public interface IMemberRepository : IGenericRepository<string, Member>
    {
        Task<Member> GetMemberByAccountAsync(string account, LoginType loginType = LoginType.Email);
        List<MemberInfoSearchObject> GetMemberInfoSearchObject(string memberId);
    }
}