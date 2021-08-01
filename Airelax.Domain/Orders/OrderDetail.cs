using System;
using Airelax.Domain.DomainObject;
using Airelax.Domain.Houses;

namespace Airelax.Domain.Orders
{
    public class OrderDetail: Entity<int>
    {
        public int HouseId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Adult { get; set; }
        public int Baby { get; set; }
        public int Child { get; set; }


        public House House { get; set; }
    }
}