using Airelax.Domain.Houses.Defines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airelax.Application.Houses.Dtos.Request
{
     public class UpdateHouseFacilitiesInput
    {
        public List<Facility> ProvideFacilities { get; set; }
    }
}
