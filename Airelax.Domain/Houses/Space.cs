using Airelax.Domain.DomainObject;
using Airelax.Domain.Houses.Defines.Spaces;

namespace Airelax.Domain.Houses
{
    public class Space:Entity<int>
    {
        public int HouseId { get; set; }
        public SpaceType SpaceType { get; set; }
        public bool IsShared { get; set; }
    }
}