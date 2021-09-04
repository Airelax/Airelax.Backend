using Airelax.Domain.Comments;
using Airelax.Domain.Orders;
using System.Collections.Generic;
using System.Linq;

namespace Airelax
{
    public interface ICommentsRepository
    {
        void Add(Comment comment);
        IEnumerable<IGrouping<string, HouseCommentObject>> Get(string memberId);
        Order GetCustomerIdAndHouseIdByOrder(string OrderId);
        string GetMemberIdByHouse(string OrderId);
        void SaveChanges();
    }
}