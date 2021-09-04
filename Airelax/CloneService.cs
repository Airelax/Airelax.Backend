using Airelax.Domain.Comments;
using Airelax.Domain.Houses;
using Airelax.Domain.Members;
using Airelax.Domain.Orders;
using Lazcat.Infrastructure.DependencyInjection;
using Lazcat.Infrastructure.ExceptionHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airelax
{
    [DependencyInjection(typeof(ICloneService))]
    public class CloneService : ICloneService
    {
        private readonly ICloneRepository _cloneRepository;

        public CloneService(ICloneRepository cloneRepository)
        {
            _cloneRepository = cloneRepository;
        }
        private void CheckCustomerIdAndHouseId(Order CustomerIdAndHouseId)
        {
            if (CustomerIdAndHouseId == null)
                throw ExceptionBuilder.Build(System.Net.HttpStatusCode.BadRequest, $"doesnt match HouseId or OrderId ");
        }
        public void CreateComment(CreateCommentInput input)
        {
            var CustomerIdAndHouseId = _cloneRepository.GetCustomerIdAndHouseIdByOrder(input.OrderId);
            CheckCustomerIdAndHouseId(CustomerIdAndHouseId);

            var OwnerId = _cloneRepository.GetMemberIdByHouse(input.OrderId);

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

            _cloneRepository.Add(comment);
            _cloneRepository.SaveChanges();
        }
    }
}
