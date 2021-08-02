using Airelax.Domain.DomainObject;
using Airelax.Domain.Orders.Define;

namespace Airelax.Domain.Orders
{
    public class Payment: Entity<int>
    {
        public PayState PayState { get; set; }
        public PayType PayType { get; set; }
        public decimal? Refund { get; set; }
    }
}