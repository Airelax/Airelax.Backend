using Airelax.Domain.Houses.Defines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airelax
{
    public class MyHouseViewModel
    {
        public string Title { get; set; }
        public HouseStatus HouseStatus { get; set; }
        public CreateState CreateState { get; set; }
        public bool CanRealTime { get; set; }
        public string Location { get; set; }
        public DateTime LastReservationTime { get; set; }
    }
}
