using Airelax.Domain.Members;

namespace Airelax
{
    public interface IMemberRepository
    {
        
        Member GetMember(string memberId);
        void SaveChanges();
        void Update(Member member);

        MemberTables GetMemberTables(string memberId);
    }
}