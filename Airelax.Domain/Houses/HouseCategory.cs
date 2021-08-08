using Airelax.Domain.DomainObject;
using Airelax.Domain.Houses.Defines;

namespace Airelax.Domain.Houses
{
    public class HouseCategory:Entity<int>
    {
        public Category Category{ get; set; }
        public HouseType HouseType { get; set; }
        public RoomCategory RoomCategory { get; set; }
    }
}