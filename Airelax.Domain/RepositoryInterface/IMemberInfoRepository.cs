using System.Collections.Generic;
using System.Threading.Tasks;
using Airelax.Controllers;
using Airelax.Domain.Members;

namespace Airelax.Domain.RepositoryInterface
{
    public interface IMemberInfoRepository
    {
        void Add(MemberInfo memberInfo);
        List<MemberInfoSearchObject> GetMemberInfoSearchObject(string memberId);
        void SaveChanges();
        void Update(MemberInfo input);
        Task Update(Member member);
        Task SaveChangeAsync();
        MemberWithMemberInfo GetMemberWithMemberInfo(string memberId);
    }
}