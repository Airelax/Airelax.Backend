using System.Collections.Generic;
using Airelax.Domain.Houses.Defines;

namespace Airelax.Application.ManageHouses.Request
{
    public class HouseFacilityInput
    {
        public List<Facility> ProvideFacilities { get; set; }
        public List<Facility> NotProvideFacilities { get; set; }
    }
}