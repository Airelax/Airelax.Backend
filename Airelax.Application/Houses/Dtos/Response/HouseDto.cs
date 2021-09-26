using System.Collections.Generic;

namespace Airelax.Application.Houses.Dtos.Response
{
    public class HouseDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<string> Pictures { get; set; }
        public int CancelPolicy { get; set; }
        public WishListDto WishList { get; set; }
        public IEnumerable<HonorDto> Honor { get; set; }
        public DescriptionDto Description { get; set; }
        public SimpleSpaceDto Space { get; set; }
        public PriceDto Price { get; set; }
        public IEnumerable<BedroomDetailDto> BedroomDetail { get; set; }
        public FacilityDto Facility { get; set; }
        public RankDto Rank { get; set; }
        public IEnumerable<CommentDto> Comments { get; set; }
        public LocationDto LocationDto { get; set; }
        public OwnerDto Owner { get; set; }
        public HouseRuleDto HouseRule { get; set; }
    }
}