using Airelax.Domain.Members;

namespace Airelax
{
    public interface IMemberRepository
    {
        void Delete(Member member);
        Member Get(string memberId);
        void SaveChange();
        void Update(Member member);
    }
}