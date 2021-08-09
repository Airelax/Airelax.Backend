using System.Collections.Generic;
using Airelax.Domain.DomainObject;

namespace Airelax.Domain.Houses.Price
{
    public class Discount
    {
        public int Week { get; set; }
        public int Month { get; set; }
        public IList<DiscountDetail> OtherDiscount { get; set; }
    }
}