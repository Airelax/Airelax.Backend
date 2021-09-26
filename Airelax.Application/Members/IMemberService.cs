using System.Threading.Tasks;
using Airelax.Application.Members.Dtos.Request;
using Airelax.Application.Members.Dtos.Response;
using Airelax.Domain.Members;
using Microsoft.AspNetCore.Mvc;

namespace Airelax.Application.Members
{
    public interface IMemberService
    {
        Task<bool> EditMember([FromBody] EditMemberInput input);
        MemberViewModel GetMemberViewModel();
        Task<bool> EditLoginAndSecurity([FromBody] LoginAndSecurityInput input);
    }
}