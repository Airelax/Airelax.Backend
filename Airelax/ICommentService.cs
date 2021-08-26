using System.Collections.Generic;

namespace Airelax
{
    public interface ICommentService
    {
        IEnumerable<HouseCommentViewModel> GetHouseComments(string memberId);
    }
}