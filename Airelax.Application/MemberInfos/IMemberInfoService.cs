using System.Threading.Tasks;
using Airelax.Application.MemberInfos.Request;
using Airelax.Application.MemberInfos.Response;
using Microsoft.AspNetCore.Mvc;

namespace Airelax.Application.MemberInfos
{
    public interface IMemberInfoService
    {
        Task<UpdateMemberInfoInput> UpdateMemberInfo([FromBody] UpdateMemberInfoInput input);
        MemberInfoViewModel GetMemberInfoViewModel(string memberId = null);
        Task<string> UpdateCover(EditPhotoInput input);
    }
}