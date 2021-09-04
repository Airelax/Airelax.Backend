using Airelax.Domain.Comments;
using Airelax.Domain.Orders;
using Lazcat.Infrastructure.DependencyInjection;
using Lazcat.Infrastructure.ExceptionHandlers;
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
                    CommentTime = c.Comment.CommentTime.ToString("yyyy/MM"),
                    Content = c.Comment.Content,
                    AuthorName = c.Members,
                    Stars = c.Stars.Total
                }).ToArray()
            });

            return commentViewModels;
        }
        private void CheckCustomerIdAndHouseId(Order CustomerIdAndHouseId)
        {
            if (CustomerIdAndHouseId == null)
                throw ExceptionBuilder.Build(System.Net.HttpStatusCode.BadRequest, $"doesnt match HouseId or OrderId ");
        }
        public void CreateComment(CreateCommentInput input)
        {
            var CustomerIdAndHouseId = _commentsRepository.GetCustomerIdAndHouseIdByOrder(input.OrderId);
            CheckCustomerIdAndHouseId(CustomerIdAndHouseId);

            var OwnerId = _commentsRepository.GetMemberIdByHouse(input.OrderId);

            var comment = new Comment(CustomerIdAndHouseId.CustomerId, CustomerIdAndHouseId.HouseId, OwnerId, input.OrderId, input.Content)
            {
                AuthorId = CustomerIdAndHouseId.CustomerId,
                HouseId = CustomerIdAndHouseId.HouseId,
                ReceiverId = OwnerId,
                OrderId = input.OrderId,
                Content = input.Content,
                CommentTime = DateTime.Now,
                LastModifyTime = DateTime.Now,

            };

            comment.Star = new Star(comment.Id, input.CleanScore, input.CommunicationScore, input.ExperienceScore, input.CheapScore, input.LocationScore, input.AccuracyScore);

            _commentsRepository.Add(comment);
            _commentsRepository.SaveChanges();
        }
    }
}
