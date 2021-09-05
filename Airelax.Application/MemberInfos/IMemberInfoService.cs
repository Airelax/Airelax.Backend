using System.Threading.Tasks;
using Airelax.Application.MemberInfos.Request;
using Airelax.Application.MemberInfos.Response;
using Microsoft.AspNetCore.Mvc;

namespace Airelax.Application.MemberInfos
{
    public interface IMemberInfoService
    {
        MemberInfoInput GetAboutMe(string memberId, [FromBody] MemberInfoInput input);
        MemberInfoViewModel GetMemberInfoViewModel(string memberId);
        Task<string> UpdateCover(string memberId, EditPhotoInput input);
    }
}