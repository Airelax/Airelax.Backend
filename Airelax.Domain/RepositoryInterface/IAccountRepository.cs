using Airelax.Domain.Members;

namespace Airelax.Domain.RepositoryInterface
{
    public interface IAccountRepository
    {
        MemberLoginInfo GetMemberInfoByAccount(string account);

        Member GetMemByEmail(string email);
        Member GetMemByAccount(string account);

        void SaveChange();
        void Update(Member mem);
        void Update(MemberLoginInfo memInfo);
        void AddMem(Member mem);
        void AddMemInfo(MemberLoginInfo memInfo);
        void UpdateToken(string id, string token);
    }
}