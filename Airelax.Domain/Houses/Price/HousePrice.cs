using System;
using Airelax.Domain.DomainObject;

namespace Airelax.Domain.Houses.Price
{
    public class HousePrice : Entity<string>
    {
        public decimal PerNight { get; set; }
        public decimal? PerWeekNight { get; set; }

        public Fee Fee { get; set; }
        public Discount Discount { get; set; }

        public HousePrice(string id)
        {
            Id = id;
        }

        public decimal CalculateTotalPrice(DateTime checkin)
        {
            return 0;
        }
    }
}