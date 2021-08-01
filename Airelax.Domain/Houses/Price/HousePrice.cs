using Airelax.Domain.DomainObject;

namespace Airelax.Domain.Houses.Price
{
    public class HousePrice: Entity<int>
    {
        public decimal PerNight { get; set; }
        public decimal PerWeekNight { get; set; }
        
        public Fee Fee { get; set; }
        public Discount Discount { get; set; }
    }
}