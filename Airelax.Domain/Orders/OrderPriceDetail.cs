﻿using Airelax.Domain.DomainObject;
using Airelax.Domain.Houses.Price;

namespace Airelax.Domain.Orders
{
    public class OrderPriceDetail : Entity<int>
    {
        public decimal PricePerNight { get; set; }
        public Discount Discount { get; set; }
        public Fee Fee { get; set; }
        public decimal Total { get; set; }

        public OrderPriceDetail(int id)
        {
            Id = id;
        }
    }
}