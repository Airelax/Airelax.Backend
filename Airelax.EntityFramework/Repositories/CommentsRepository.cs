using System.Collections.Generic;
using System.Linq;
using Airelax.Domain.Comments;
using Airelax.Domain.Orders;
using Airelax.Domain.RepositoryInterface;
using Airelax.EntityFramework.DbContexts;
using Lazcat.Infrastructure.DependencyInjection;

namespace Airelax.EntityFramework.Repositories
{
    [DependencyInjection(typeof(ICommentsRepository))]
    public class CommentsRepository : ICommentsRepository
    {
        private readonly AirelaxContext _context;

        public CommentsRepository(AirelaxContext context)
        {
            _context = context;
        }

        public IEnumerable<IGrouping<string, HouseCommentObject>> Get(string memberId)
        {
            var comments =
                (from c in _context.Comments
                    join m in _context.Members on c.ReceiverId equals m.Id
                    join mem in _context.Members on c.AuthorId equals mem.Id
                    join h in _context.Houses on c.HouseId equals h.Id
                    join s in _context.Stars on c.Id equals s.Id
                    where m.Id == memberId
                    select new HouseCommentObject {Comment = c, HouseId = h.Id, HouseName = h.Title, HouseStatus = h.Status, Members = mem.Name, Stars = s}).ToList();
            var commentsGroup = comments.GroupBy(x => x.HouseId);


            return commentsGroup;
        }

        public Order GetCustomerIdAndHouseIdByOrder(string orderId)
        {
            var CustomerIdAndHouseId = _context.Orders
                .FirstOrDefault(o => o.Id == orderId);
            return CustomerIdAndHouseId;
        }

        public string GetMemberIdByHouse(string orderId)
        {
            var OwnerId = _context.Houses
                .FirstOrDefault(h => h.Id == GetCustomerIdAndHouseIdByOrder(orderId).HouseId).OwnerId;
            return OwnerId;
        }

        public void Add(Comment comment)
        {
            _context.Comments.Add(comment);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}