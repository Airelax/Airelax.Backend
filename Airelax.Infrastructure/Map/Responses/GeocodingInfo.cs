using System.Collections.Generic;
using Airelax.Infrastructure.Map.GoogleResponses.GeocodingResponses;

namespace Airelax.Infrastructure.Map.Responses
{
    public class GeocodingInfo
    {
        public Coordinate Location { get; set; }
        public CoordinateRange Bounds { get; set; }
        public CoordinateRange Viewport { get; set; }
        public List<AddressComponent> AddressComponent { get; set; }
    }
}