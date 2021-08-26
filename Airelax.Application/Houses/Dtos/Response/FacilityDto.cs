using System.Collections.Generic;

namespace Airelax.Application.Houses.Dtos.Response
{
    public class FacilityDto
    {
        public IEnumerable<int> Provide { get; set; }
        public IEnumerable<int> NotProvide { get; set; }
    }
}