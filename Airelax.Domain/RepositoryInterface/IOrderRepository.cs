using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Airelax.Domain.Orders;

namespace Airelax.Domain.RepositoryInterface
{
    public interface IOrderRepository
    {
        void Add(Order order);
        void SaveChanges();
        Task<Order> GetOrderAsync(Expression<Func<Order, bool>> expression);
        void Update(Order order);
    }
}