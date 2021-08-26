using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airelax.Domain.Houses.Defines;

namespace Airelax.Application.Houses.Dtos.Request.ManageHouse
{
    public class HouseFacilityInput
    {
        public List<Facility> ProvideFacilities { get; set; }
        public List<Facility> NotProvideFacilities { get; set; }
    }
}
