using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airelax.Application.Houses.Dtos.Request.ManageHouse
{
    public class HouseSpaceInput
    {
        public string HouseId { get; set; }
        public int SpaceType { get; set; }
        public bool IsShared { get; set; }
    }
}
