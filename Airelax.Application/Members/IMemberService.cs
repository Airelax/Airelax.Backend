using System.Threading.Tasks;
using Airelax.Application.Members.Dtos.Request;
using Airelax.Application.Members.Dtos.Response;
using Airelax.Domain.Members;
using Microsoft.AspNetCore.Mvc;

namespace Airelax.Application.Members
{
    public interface IMemberService
    {
        Task<bool> EditMember(string memberId, [FromBody] EditMemberInput input);
        MemberViewModel GetMemberViewModel(string memberId);
        Member JudgeMember(string memberId);
        Task<bool> EditLoginAndSecurity(string memberId, [FromBody] LoginAndSecurityInput input);
    }
}