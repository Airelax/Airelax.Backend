using Airelax.Domain.DomainObject;

namespace Airelax.Domain.Members
{
    public class MemberLoginInfo: Entity<string>
    {
        public string Account { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public string ThirdPartyToken { get; set; }
        public string ThirdPartyRefreshToken { get; set; }
    }
}