using Lazcat.Infrastructure.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airelax
{
    [DependencyInjection(typeof(ICommentService))]
    public class CommentService : ICommentService
    {
        private readonly ICommentsRepository _commentsRepository;

        public CommentService(ICommentsRepository commentsRepository)
        {
            _commentsRepository = commentsRepository;
        }
        public IEnumerable<HouseCommentViewModel> GetHouseComments(string memberId)
        {
            var comments = _commentsRepository.Get(memberId);

            if (comments == null || !comments.Any()) return null;
            var commentViewModels = comments.Select(com => new HouseCommentViewModel()
            {
                HouseId = com.Key,
                HouseName = com.First().HouseName,
                HouseState = (int)com.First().HouseStatus,
                Comments = com.Select(c => new CommentViewModel()
                {
                    CommentId = c.Comment.Id,
                    CommentTime = c.Comment.CommentTime,
                    Content = c.Comment.Content,
                    AuthorName = c.Members,
                    Stars = c.Stars.Total
                }).ToArray()
            });

            return commentViewModels;
        }
    }
}
