﻿using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Airelax.Domain.Members;
using Airelax.Domain.Orders;
using Airelax.Domain.RepositoryInterface;
using Airelax.EntityFramework.DbContexts;
using Lazcat.Infrastructure.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

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

        //public Order GetOrder(string houseId)
        //{
        //    //串Orders/OrderDetail/OrderPriceDetail/Payment
        //    return _context.Orders
        //            .Include(x => x.OrderDetail)
        //            .Include(x => x.OrderPriceDetail)
        //            .Include(x => x.Payment)
        //            .FirstOrDefault(x => x.HouseId == houseId);
        //}

        public async Task<Order> GetOrderAsync(Expression<Func<Order, bool>> expression)
        {
            return await GetOrderIncludeAll().FirstOrDefaultAsync(expression);
        }

        public void Update(Order order)
        {
            _context.Orders.Update(order);
        }
        
        public void Add(Order order)
        {
            _context.Orders.Add(order);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        private IIncludableQueryable<Order, Member> GetOrderIncludeAll()
        {
            return _context.Orders.Include(x=>x.OrderDetail)
                .Include(x=>x.OrderPriceDetail)
                .Include(x=>x.Payment)
                .Include(x=>x.House)
                .Include(x=>x.Member);
        }
    }
}