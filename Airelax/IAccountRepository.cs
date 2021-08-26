using Airelax.Domain.Members;

namespace Airelax
{
    public interface IAccountRepository
    {
        MemberLoginInfo GetAccountByAccount(string account);
        MemberLoginInfo GetAccountByEmail(string email);
        Member GetEmailByEmail(string email);
        string GetIdByEmail(string email);
        void SaveChange();
        void Update(Member mem);
        void Update(MemberLoginInfo memInfo);
        void addMem(Member mem);
        void addMemInfo(MemberLoginInfo meminfo);
    }
}