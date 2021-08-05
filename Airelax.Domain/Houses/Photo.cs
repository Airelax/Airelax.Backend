using Airelax.Domain.DomainObject;

namespace Airelax.Domain.Houses
{
    public class Photo : Entity<int>
    {
        public int? SpaceId { get; set; }
        public int HouseId { get; set; }
        public byte[] Image { get; set; }


        public Photo(int houseId)
        {
            HouseId = houseId;
        }
    }
}