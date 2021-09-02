using Airelax.Domain.Members;

namespace Airelax
{
    public interface IAccountRepository
    {
        MemberLoginInfo GetMeminfoByAccount(string account);
      
        Member GetMemByEmail(string email);
        Member GetMemByAccount(string account);
        
        void SaveChange();
        void Update(Member mem);
        void Update(MemberLoginInfo memInfo);
        void addMem(Member mem);
        void addMemInfo(MemberLoginInfo meminfo);
        void UpdateToken(string id, string token);
    }
}