using System;
using System.Collections.Generic;
using System.Linq;
using Airelax.Application.Houses.Dtos.Response;
using Airelax.Domain.Comments;
using Airelax.Domain.Houses;
using Airelax.Domain.Houses.Price;
using Airelax.Domain.Members;
using AutoMapper;

namespace Airelax.Application
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<House, HouseDto>()
                .ForMember(x => x.Description, x => x.MapFrom(m => m.HouseDescription));

            CreateMap<Member, OwnerDto>().ForMember(x => x.IsVerified, opt => opt.MapFrom(x => x.IsEmailVerified));
            CreateMap<MemberInfo, OwnerDto>().ForMember(x => x.Id, x => x.Ignore());
            CreateMap<WishList, WishListDto>().ForMember(des => des.Cover, opt => opt.MapFrom(x => ConvertToBase64String(x.Cover)));
            CreateMap<HouseDescription, DescriptionDto>().ForMember(x => x.HouseDescription, x => x.MapFrom(y => y.Description));
            CreateMap<Comment, CommentDto>().ForMember(x => x.Date, opt => opt.MapFrom(x => x.CommentTime));
            CreateMap<HouseLocation, LocationDto>();
            CreateMap<BedroomDetailDto, BedroomDetail>().ForMember(x => x.BedType, opt => opt.MapFrom(x => x.BedType.ToString()));
            CreateMap<Policy, HouseRuleDto>();
            CreateMap<HouseRule, HouseRuleDto>();
            CreateMap<Fee, FeeDto>();
            CreateMap<Discount, DiscountDto>();
            CreateMap<HousePrice, PriceDto>().ForMember(x => x.Origin, opt => opt.MapFrom(x => x.PerNight))
                .ForMember(x => x.SweetPrice, opt => opt.MapFrom(x => x.PerWeekNight));
        }


        private static string ConvertToBase64String(byte[] bytes)
        {
            var from = bytes;
            if (bytes == null) from = Array.Empty<byte>();
            return Convert.ToBase64String(from);
        }
    }
}