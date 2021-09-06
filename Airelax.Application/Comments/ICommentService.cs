using System.Collections.Generic;
using Airelax.Application.Comments.Dtos.Request;
using Airelax.Application.Comments.Dtos.Response;

namespace Airelax.Application.Comments
{
    public interface ICommentService
    {
        void CreateComment(CreateCommentInput input);
        IEnumerable<HouseCommentViewModel> GetHouseComments();
    }
}