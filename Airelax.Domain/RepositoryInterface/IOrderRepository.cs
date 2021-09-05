using Airelax.Domain.Orders;

namespace Airelax.Domain.RepositoryInterface
{
    public interface IOrderRepository
    {
        void Add(Order order);
        void SaveChanges();
    }
}