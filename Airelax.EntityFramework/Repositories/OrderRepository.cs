using Airelax.Domain.Orders;
using Airelax.Domain.RepositoryInterface;
using Airelax.EntityFramework.DbContexts;
using Lazcat.Infrastructure.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airelax.EntityFramework.Repositories
{
    [DependencyInjection(typeof(IOrderRepository))]
    public class OrderRepository : IOrderRepository
    {
        private readonly AirelaxContext _context;

        public OrderRepository(AirelaxContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Order>> GetTrips(string memberId)
        {
            var trips = await _context.Orders
                .Include(x => x.OrderDetail)
                .Include(x => x.House)
                .ThenInclude(x => x.HouseLocation)
                .Include(x => x.House)
                .ThenInclude(x => x.Photos)
                .Where(x => x.CustomerId == memberId).ToListAsync();

            return trips;
        }

        //public Order GetOrder(string houseId)
        //{
        //    //串Orders/OrderDetail/OrderPriceDetail/Payment
        //    return _context.Orders
        //            .Include(x => x.OrderDetail)
        //            .Include(x => x.OrderPriceDetail)
        //            .Include(x => x.Payment)
        //            .FirstOrDefault(x => x.HouseId == houseId);
        //}
        public void Add(Order order)
        {
            _context.Orders.Add(order);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}