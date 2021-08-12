using System.Collections.Generic;
using Airelax.Domain.Houses.Defines;

namespace Airelax.Application.Houses
{
    public class Definition
    {
        public static IEnumerable<Facility> SimpleFacilities { get; }
            = new List<Facility> {Facility.Kitchen, Facility.AirConditioner, Facility.Wifi, Facility.WashMachine};
    }
}