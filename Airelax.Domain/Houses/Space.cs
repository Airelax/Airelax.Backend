using System.Collections;
using System.Collections.Generic;
using Airelax.Domain.DomainObject;
using Airelax.Domain.Houses.Defines.Spaces;

namespace Airelax.Domain.Houses
{
    public class Space : Entity<string>
    {
        public string HouseId { get; set; }
        public SpaceType SpaceType { get; set; }
        public bool IsShared { get; set; }

        public ICollection<BedroomDetail> BedroomDetails { get; set; }

        public Space(string houseId)
        {
            HouseId = houseId;
            SpaceType = SpaceType.Bedroom;
            IsShared = false;
        }
    }
}