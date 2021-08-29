using Airelax.Domain.Members;

namespace Airelax
{
    public interface IAccountRepository
    {
        MemberLoginInfo GetAccountByAccount(string account);
        MemberLoginInfo GetAccountByEmail(string email);
        Member GetEmailByEmail(string email);
        Member GetMemByAccount(string account);
        string GetIdByEmail(string email);
        string GetCoverByEmail(string email);
        string GetNameByEmail(string email);
        void SaveChange();
        void Update(Member mem);
        void Update(MemberLoginInfo memInfo);
        void addMem(Member mem);
        void addMemInfo(MemberLoginInfo meminfo);
        void UpdateToken(string id, string token);
    }
}