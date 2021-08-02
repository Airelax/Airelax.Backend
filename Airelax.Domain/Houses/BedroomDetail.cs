using Airelax.Domain.DomainObject;
using Airelax.Domain.Houses.Defines.Spaces;

namespace Airelax.Domain.Houses
{
    public class BedroomDetail: Entity<int>
    {
        public BedType BedType { get; set; }
        public int BedCount { get; set; }
        public bool HasIndependentBath { get; set; }
    }
}