using System.Collections.Generic;
using Airelax.Application.Comments.Dtos.Request;
using Airelax.Application.Comments.Dtos.Response;

namespace Airelax.Application.Comments
{
    public interface ICommentService
    {
        void CreateOrUpdateComment(CreateOrUpdateCommentInput input);
        IEnumerable<HouseCommentViewModel> GetHouseComments();
    }
}