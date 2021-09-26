using System.Collections.Generic;

namespace Airelax.Application.Houses.Dtos.Response
{
    public class SimpleHouseDto
    {
        public string Id { get; set; }
        public IEnumerable<string> Picture { get; set; }
        public WishListDto WishList { get; set; }
        public string Address { get; set; }
        public string HouseType { get; set; }
        public string Title { get; set; }
        public SimpleSpaceDto Space { get; set; }
        public SimpleFacilityDto Facility { get; set; }
        public PriceDto Price { get; set; }
        public SimpleCommentDto Comment { get; set; }
        public CoordinateDto Coordinate { get; set; }
    }
}