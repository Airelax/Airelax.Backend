using System.Collections.Generic;
using Airelax.Infrastructure.Map.Responses;

namespace Airelax.Application.Houses.Dtos.Response
{
    public class SearchHousesResponse
    {
        public LocationInfoDto LocationInfo { get; set; }
        public IEnumerable<SimpleHouseDto> Houses { get; set; }
    }
}