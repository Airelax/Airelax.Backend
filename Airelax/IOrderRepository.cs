using Airelax.Domain.Orders;

namespace Airelax
{
    public interface IOrderRepository
    {
        void Add(Order order);
        void SaveChanges();
    }
}