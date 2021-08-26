using System.Collections.Generic;
using System.Linq;

namespace Airelax
{
    public interface ICommentsRepository
    {
        IEnumerable<IGrouping<string, HouseCommentObject>> Get(string memberId);
    }
}