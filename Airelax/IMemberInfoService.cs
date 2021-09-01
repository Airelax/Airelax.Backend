using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Airelax.Application.MemberInfo.Request;

namespace Airelax
{
    public interface IMemberInfoService
    {
        MemberInfoInput GetAboutMe(string memberId, [FromBody] MemberInfoInput input);
        MemberInfoViewModel GetMemberInfoViewModel(string memberId);
        Task<string> UpdateCover(string memberId, EditPhotoInput input);
    }
}