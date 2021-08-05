using Airelax.Domain.DomainObject;

namespace Airelax.Domain.Houses
{
    public class HouseLocation : Entity<int>
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Town { get; set; }
        public string ZipCode { get; set; }
        public string AddressDetail { get; set; }
        public string LocationDescription { get; set; }
        public string TrafficDescription { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public HouseLocation(int id)
        {
            Id = id;
            Country = "台灣";
            City = "台北市";
            Town = "中正區";
        }
    }
}