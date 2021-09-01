using Airelax.Controllers;
using Airelax.Domain.Members;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Airelax
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