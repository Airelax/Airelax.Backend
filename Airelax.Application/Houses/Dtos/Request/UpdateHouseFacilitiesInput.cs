using System.Collections.Generic;
using Airelax.Domain.Houses.Defines;

namespace Airelax.Application.Houses.Dtos.Request
{
    public class UpdateHouseFacilitiesInput
    {
        public List<Facility> ProvideFacilities { get; set; }
    }
}