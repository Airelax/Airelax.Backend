using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Airelax.Application.Account;
using Airelax.Application.Comments.Dtos.Request;
using Airelax.Application.Comments.Dtos.Response;
using Airelax.Application.Houses.Dtos.Response;
using Airelax.Domain.Comments;
using Airelax.Domain.Orders;
using Airelax.Domain.RepositoryInterface;
using Lazcat.Infrastructure.DependencyInjection;
using Lazcat.Infrastructure.ExceptionHandlers;
using Lazcat.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Airelax.Application.Comments
{
    [DependencyInjection(typeof(ICommentService))]
    public class CommentService : ICommentService
    {
        private readonly ICommentsRepository _commentsRepository;
        private readonly IAccountService _accountService;

        public CommentService(ICommentsRepository commentsRepository, IAccountService accountService)
        {
            _commentsRepository = commentsRepository;
            _accountService = accountService;
        }

        public IEnumerable<HouseCommentViewModel> GetHouseComments()
        {
            var memberId = _accountService.GetAuthMemberId();
            
            var comments = _commentsRepository.Get(memberId)?.ToList();

            if (comments == null || !comments.Any()) return new List<HouseCommentViewModel>();
            var commentViewModels = comments.Select(com => new HouseCommentViewModel
            {
                HouseId = com.Key,
                HouseName = com.First().HouseName,
                HouseState = (int) com.First().HouseStatus,
                Comments = com.Select(c => new CommentViewModel
                {
                    CommentId = c.Comment.Id,
                    CommentTime = c.Comment.CommentTime.ToString("yyyy/MM"),
                    Content = c.Comment.Content,
                    AuthorName = c.AuthorName,
                    Stars = c.Stars.Total
                }).ToArray()
            });

            return commentViewModels;
        }

        public void CreateComment(CreateCommentInput input)
        {
            var order = _commentsRepository.GetOrder(input.OrderId);
            CheckOrder(order);

            var ownerId = order.House.OwnerId;

            var comment = new Comment(order.CustomerId, order.HouseId, ownerId, input.OrderId, input.Content)
            {
                AuthorId = order.CustomerId,
                HouseId = order.HouseId,
                ReceiverId = ownerId,
                OrderId = input.OrderId,
                Content = input.Content,
                CommentTime = DateTime.Now,
                LastModifyTime = DateTime.Now
            };

            comment.Star = new Star(comment.Id, input.CleanScore, input.CommunicationScore, input.ExperienceScore, input.CheapScore, input.LocationScore, input.AccuracyScore);

            _commentsRepository.Add(comment);
            _commentsRepository.SaveChanges();
        }
        

        private void CheckOrder(Order order)
        {
            if (order == null)
                throw ExceptionBuilder.Build(HttpStatusCode.BadRequest, "doesnt match HouseId or OrderId ");
        }
    }
}