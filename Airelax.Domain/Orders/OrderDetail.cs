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

        public OrderDetail(string id, DateTime startDate, DateTime endDate, int adult, int baby, int child)
        {
            Id = id;
            StartDate = startDate;
            EndDate = endDate;
            Adult = adult;
            Baby = baby;
            Child = child;
        }
    }
}