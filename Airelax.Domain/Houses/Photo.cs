using Airelax.Domain.DomainObject;

namespace Airelax.Domain.Houses
{
    public class Photo:Entity<int>
    {
        public int HouseId { get; set; }
        public byte[] Image { get; set; }
    }
}