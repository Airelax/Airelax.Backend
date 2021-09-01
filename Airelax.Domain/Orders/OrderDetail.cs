using System;
using Airelax.Domain.DomainObject;

namespace Airelax.Domain.Orders
{
    public class OrderDetail : Entity<string>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Adult { get; set; }
        public int Baby { get; set; }
        public int Child { get; set; }

        public OrderDetail(string id)
        {
            Id = id;
        }
    }
}