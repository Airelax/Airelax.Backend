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
    [DependencyInjection(typeof(IOrderRepository))]
    public class OrderRepository : IOrderRepository
    {
        private readonly AirelaxContext _context;
        public OrderRepository(AirelaxContext context)
        {
            _context = context;
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
