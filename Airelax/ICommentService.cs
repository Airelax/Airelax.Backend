using System.Collections.Generic;

namespace Airelax
{
    public interface ICommentService
    {
        void CreateComment(CreateCommentInput input);
        IEnumerable<HouseCommentViewModel> GetHouseComments(string memberId);
    }
}