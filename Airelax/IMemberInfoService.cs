using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Airelax
{
    public interface IMemberInfoService
    {
        MemberInfoInput GetAboutMe(string memberId, [FromBody] MemberInfoInput input);
        MemberInfoViewModel GetMemberInfoViewModel(string memberId);
    }
}