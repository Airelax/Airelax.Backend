using Airelax.Domain.Comments;
using Airelax.Domain.Houses;
using Airelax.Domain.Members;
using Airelax.Domain.Orders;
using Airelax.EntityFramework.DbContexts;
using Lazcat.Infrastructure.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airelax
{
    [DependencyInjection(typeof(ICloneRepository))]
    public class CloneRepository : ICloneRepository
    {
        private readonly AirelaxContext _context;
        public CloneRepository(AirelaxContext context)
        {
            _context = context;
        }
        public Order GetCustomerIdAndHouseIdByOrder(string OrderId)
        {
            var CustomerIdAndHouseId = _context.Orders
                                     .FirstOrDefault(o => o.Id == OrderId);
            return CustomerIdAndHouseId;
        }
        public string GetMemberIdByHouse(string OrderId)
        {
            var OwnerId = _context.Houses
                        .FirstOrDefault(h => h.Id == GetCustomerIdAndHouseIdByOrder(OrderId).HouseId).OwnerId;
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
