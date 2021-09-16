using Airelax.Domain.Orders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Airelax.Domain.RepositoryInterface
{
    public interface IOrderRepository
    {
        void Add(Order order);
        void SaveChanges();
        Task<IEnumerable<Order>> GetTrips(string memberId);
    }
}