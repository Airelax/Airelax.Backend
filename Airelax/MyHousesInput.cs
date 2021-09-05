using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airelax
{
    public class MyHousesInput

    {
        public string Title { get; set; }
        public string HouseStatus { get; set; }
        public string CreateState { get; set; }
        public bool CanRealTime { get; set; }
        public string Location { get; set; }
        public DateTime LastReservationTime { get; set; }
    }
}
