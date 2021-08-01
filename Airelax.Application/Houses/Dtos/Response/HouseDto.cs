﻿namespace Airelax.Application.Houses.Dtos.Response
{
    public class HouseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string[] Pictures { get; set; }
        public int CancelPolicy { get; set; }
        public WishListDto WishList { get; set; }
        public HonorDto[] Honor { get; set; }
        public DescriptionDto Description { get; set; }
        public SpaceDto Space { get; set; }
        public PriceDto Price { get; set; }
        public BedroomDetailDto[] BedroomDetail { get; set; }
        public FacilityDto Facility { get; set; }
        public RankDto Rank { get; set; }
        public CommentDto[] Comments { get; set; }
        public LocationDto LocationDto { get; set; }
        public OwnerDto Owner { get; set; }
        public HouseRuleDto HouseRule { get; set; }
    }
}