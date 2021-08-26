using Airelax.EntityFramework.DbContexts;
using Lazcat.Infrastructure.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airelax
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
                    select new HouseCommentObject { Comment = c, HouseId = h.Id, HouseName = h.Title, HouseStatus = h.Status, Members = mem.Name, Stars = s }).ToList();
            var commentsGroup = comments.GroupBy(x => x.HouseId);


            return commentsGroup;
        }
    }
}
