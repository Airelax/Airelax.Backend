using Airelax.Domain.DomainObject;

namespace Airelax.Domain.Houses
{
    public class Photo : Entity<int>
    {
        public string SpaceId { get; set; }
        public string HouseId { get; set; }
        public string Image { get; set; }

        public Photo(string houseId)
        {
            HouseId = houseId;
        }
    }
}