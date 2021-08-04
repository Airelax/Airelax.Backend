using System;
using Airelax.Domain.Comments;
using Airelax.Domain.DomainObject;
using Airelax.Domain.Houses;
using Airelax.Domain.Orders.Define;

namespace Airelax.Domain.Orders
{
    public class Order: AggregateRoot<int>
    {
        public int CustomerId { get; set; }
        public int HouseId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime LastModifyTime { get; set; }
        public OrderState State { get; set; }
    }
}