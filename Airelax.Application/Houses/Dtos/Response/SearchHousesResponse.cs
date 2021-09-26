using System.Collections.Generic;

namespace Airelax.Application.Houses.Dtos.Response
{
    public class SearchHousesResponse
    {
        public int Total { get; set; }
        public LocationInfoDto LocationInfo { get; set; }
        public IEnumerable<SimpleHouseDto> Houses { get; set; } = new List<SimpleHouseDto>();
    }
}