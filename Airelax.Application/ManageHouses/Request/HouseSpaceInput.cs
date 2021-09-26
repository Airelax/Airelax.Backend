using System;

namespace Airelax.Application.ManageHouses.Request
{
    public class HouseSpaceInput
    {
        public string Id { get; set; }
        public string HouseId { get; set; }
        public int SpaceType { get; set; }
        public bool IsShared { get; set; }
    }
}