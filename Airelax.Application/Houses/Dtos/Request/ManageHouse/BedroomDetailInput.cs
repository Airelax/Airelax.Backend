using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airelax.Application.Houses.Dtos.Request.ManageHouse
{
    public class BedroomDetailInput
    {
        public string SpaceId { get; set; }
        public int? BedType { get; set; }
        public int? BedCount { get; set; }
        public bool? HasIndependentBath { get; set; }
    }
}
