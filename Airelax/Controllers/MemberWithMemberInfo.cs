using Airelax.Domain.Members;

namespace Airelax.Controllers
{
    public class MemberWithMemberInfo
    {
        public Member Member { get; set; }
        public MemberInfo MemberInfos { get; set; }
    }
}