using Airelax.Application.Members.Request;
using Airelax.Domain.Members;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Airelax
{
    public interface IMemberService
    {
        Task<bool> EditMember(string memberId, [FromBody] EditMemberInput input);
        MemberViewModel GetMemberViewModel(string memberId);
        Member JudgeMember(string memberId);
        Task<bool> EditLoginAndSecurity(string memberId, [FromBody] LoginAndSecurityInput input);
    }
}