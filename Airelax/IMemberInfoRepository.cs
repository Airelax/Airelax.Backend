using Airelax.Controllers;
using Airelax.Domain.Members;
using System.Collections.Generic;

namespace Airelax
{
    public interface IMemberInfoRepository
    {
        void Add(MemberInfo memberInfo);
        IEnumerable<MemberInfoSearchObject> GetMemberInfoSearchObject(string memberId);
        void SaveChanges();
        void Update(MemberInfo input);
        MemberInfoTables GetMemberInfoTables(string memberId);
    }
}