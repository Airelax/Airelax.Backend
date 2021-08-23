using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Airelax.Application.Houses.Dtos.Request;
using Airelax.Application.Houses.Dtos.Response;
using Airelax.Domain.Comments;
using Airelax.Domain.DomainObject;
using Airelax.Domain.Houses;
using Airelax.Domain.Houses.Defines;
using Airelax.Domain.Houses.Defines.Spaces;
using Airelax.Domain.Houses.Specifications;
using Airelax.Domain.RepositoryInterface;
using Lazcat.Infrastructure.DependencyInjection;
using Lazcat.Infrastructure.Map.Abstractions;
using Microsoft.EntityFrameworkCore;
using Lazcat.Infrastructure.ExceptionHandlers;
using Airelax.Domain.Members;
using Airelax.Domain.Houses.Price;
using Lazcat.Infrastructure.Extensions;
using Lazcat.Infrastructure.Map.Responses;

namespace Airelax.Application.Houses
{
    [DependencyInjection(typeof(IHouseAppService))]
    public class HouseAppService : IHouseAppService
    {
        private readonly IHouseRepository _houseRepository;
        private readonly IMemberRepository _memberRepository;
        private readonly IGeocodingService _geocodingService;


        public HouseAppService(IHouseRepository houseRepository, IMemberRepository memberRepository, IGeocodingService geocodingService)
        {
            _houseRepository = houseRepository;
            _memberRepository = memberRepository;
            _geocodingService = geocodingService;
        }

        public async Task<IEnumerable<SimpleHouseDto>> Search(SearchInput input)
        {
            Check.CheckNull(input);
            //var geocodingInfo = await _geocodingService.GetGeocodingInfo(input.Location);
            var geocodingInfo = new GeocodingInfo()
            {
                Bounds = new CoordinateRange()
                {
                    Northeast = new Coordinate(25.2103038, 121.6659421),
                    SouthWest = new Coordinate(24.9605084, 121.4570603)
                },
                Location = new Coordinate(25.0329636, 121.5654268),
                Viewport = new CoordinateRange()
                {
                    Northeast = new Coordinate(25.2103038, 121.6659421),
                    SouthWest = new Coordinate(24.9605084, 121.4570603)
                }
            };
            Specification<House> specification = new InRangeLocationSpecification(geocodingInfo.Bounds.SouthWest, geocodingInfo.Bounds.Northeast);
            var customerNumberSpecification = new MaxCustomerNumberSpecification(input.CustomerNumber);
            specification = specification.And(customerNumberSpecification);


            if (input.Checkin.HasValue && input.Checkout.HasValue)
            {
                var dateRange = GetDateRange(input.Checkin.Value, input.Checkout.Value);
                var availableDateSpecification = new AvailableDateSpecification(dateRange);
                specification = specification.And(availableDateSpecification);
            }


            var houses = _houseRepository.GetAll()
                .Include(x => x.Member)
                .ThenInclude(x => x.WishLists)
                .Include(x => x.HouseLocation)
                .Include(x => x.Comments)
                .Include(x => x.HousePrice)
                .Include(x => x.HouseCategory)
                .Include(x => x.Spaces)
                .Include(x => x.Photos)
                .Where(specification.ToExpression())
                .OrderByDescending(x => x.CreateTime)
                .Skip((input.Page - 1) * 30).Take(30)
                .ToList();

            var results = houses.Select(x =>
            {
                var simpleComment = new SearchHouseComment {Number = x.Comments?.Count ?? 0};
                if (!x.Comments.IsNullOrEmpty())
                {
                    simpleComment.Stars = Math.Round(x.Comments?.Average(c => c.Star?.Total ?? 0) ?? 0, 1);
                }

                var simpleHouse = new SearchHouse
                {
                    Id = x.Id,
                    Picture = x.Photos?.Select(p => p.Image),
                    WishList = x.Member?.WishLists,
                    Location = x.HouseLocation,
                    Price = x.HousePrice,
                    Title = x.Title,
                    Category = x.HouseCategory,
                    Facilities = x.ProvideFacilities?.Intersect(Definition.SimpleFacilities),
                    CustomerNumber = x.CustomerNumber,
                    Space = x.Spaces?.Where(s => s.SpaceType == SpaceType.Bath || s.SpaceType == SpaceType.Bedroom),
                    Comment = simpleComment
                };
                return simpleHouse;
            });

            var simpleHouseDtos = ConvertToSimpleHouseDtos(results);
            return simpleHouseDtos;
        }

        public async Task<HouseDto> GetHouse(string id)
        {
            var house = await _houseRepository.GetAsync(x => x.Id == id);
            if (house == null) throw ExceptionBuilder.Build(HttpStatusCode.BadRequest, $"House Id : {id} does not match any house");

            var member = await _memberRepository.GetAsync(x => x.Id == house.OwnerId);
            if (member == null) throw ExceptionBuilder.Build(HttpStatusCode.BadRequest, $"House exist but member has been deleted");
            var houseDto = new HouseDto()
            {
                Id = house.Id,
                Title = house.Title,
                CancelPolicy = (int) house.Policy.CancelPolicy,
                // todo photo to url
                Pictures = house.Photos.Select(x => x.Image.ToString()),
                Space = ConvertToSpaceDto(house),
                BedroomDetail = ConvertToBedroomDetailDtos(house),
                Description = ConvertToDescriptionDto(house.HouseDescription),
                Facility = ConvertToFacilityDto(house),
                Honor = new List<HonorDto>()
                {
                    //todo
                },
                Comments = new List<CommentDto>
                {
                    //todo
                },
                HouseRule = ConvertToHouseRuleDto(house.HouseRule, house.Policy),
                LocationDto = ConvertToLocationDto(house.HouseLocation),
                Owner = new OwnerDto()
                {
                    Name = member.Name,
                    Id = member.Id,
                    RegisterTime = member.RegisterTime,
                    About = member.MemberInfo.About,
                    IsVerified = member.IsEmailVerified
                },
                Rank = new RankDto()
                {
                    //todo
                },
                WishList = new WishListDto()
                {
                    //todo
                },
                Price = ConvertToPriceDto(house.HousePrice)
            };
            return houseDto;
        }

        private static PriceDto ConvertToPriceDto(HousePrice housePrice)
        {
            var price = new PriceDto()
            {
                Discount = new DiscountDto(),
                Fee = new FeeDto(),
            };
            if (housePrice == null) return price;

            price.Origin = housePrice.PerNight;
            price.SweetPrice = housePrice.PerWeekNight;
            price.Discount.Month = housePrice.Discount?.Month ?? 0;
            price.Discount.Week = housePrice.Discount?.Week ?? 0;
            price.Fee.CleanFee = housePrice.Fee?.CleanFee ?? 0;
            price.Fee.ServiceFee = housePrice.Fee?.ServiceFee ?? 0;
            price.Fee.TaxFee = housePrice.Fee?.TaxFee ?? 0;
            return price;
        }

        private static LocationDto ConvertToLocationDto(HouseLocation houseHouseLocation)
        {
            return houseHouseLocation == null
                ? new LocationDto()
                : new LocationDto
                {
                    City = houseHouseLocation.City,
                    Country = houseHouseLocation.Country,
                    Town = houseHouseLocation.Town,
                    Latitude = houseHouseLocation.Latitude,
                    Longitude = houseHouseLocation.Longitude
                };
        }

        private static HouseRuleDto ConvertToHouseRuleDto(HouseRule houseHouseRule, Policy policy)
        {
            var houseRuleDto = new HouseRuleDto();
            if (houseHouseRule != null)
            {
                houseRuleDto.AllowChild = houseHouseRule.AllowChild;
                houseRuleDto.AllowSmoke = houseHouseRule.AllowSmoke;
                houseRuleDto.AllowBaby = houseHouseRule.AllowBaby;
                houseRuleDto.AllowParty = houseHouseRule.AllowParty;
                houseRuleDto.AllowPet = houseHouseRule.AllowParty;
            }

            if (policy == null) return houseRuleDto;
            houseRuleDto.CashPledge = policy.CashPledge ?? 0;
            houseRuleDto.CheckinTime = policy.CheckinTime.ToString("hh:mm");
            houseRuleDto.CheckoutTime = policy.CheckoutTime.ToString("hh:mm");

            return houseRuleDto;
        }

        private static DescriptionDto ConvertToDescriptionDto(HouseDescription houseHouseDescription)
        {
            return houseHouseDescription == null
                ? new DescriptionDto()
                : new DescriptionDto()
                {
                    HouseDescription = houseHouseDescription.Description,
                    GuestPermission = houseHouseDescription.GuestPermission,
                    Others = houseHouseDescription.Others,
                    SpaceDescription = houseHouseDescription.SpaceDescription
                };
        }

        private static IEnumerable<BedroomDetailDto> ConvertToBedroomDetailDtos(House house)
        {
            return house.Spaces?.SelectMany(x => x.BedroomDetails).Select(x => new BedroomDetailDto()
            {
                BedCount = x.BedCount,
                BedType = x.BedType.ToString()
            }) ?? new List<BedroomDetailDto>();
        }

        private static FacilityDto ConvertToFacilityDto(House house)
        {
            return new FacilityDto()
            {
                Provide = house.ProvideFacilities?.Select(x => (int) x),
                NotProvide = house.NotProvideFacilities?.Select(x => (int) x)
            };
        }

        private static IEnumerable<SimpleHouseDto> ConvertToSimpleHouseDtos(IEnumerable<SearchHouse> results)
        {
            return results.Select(x =>
            {
                var simpleHouseDto = new SimpleHouseDto
                {
                    Id = x.Id,
                    Address = $"{x.Location.Town ?? string.Empty}",
                    Comment = new SimpleCommentDto()
                    {
                        Star = x.Comment?.Stars,
                        TotalComments = x.Comment?.Number
                    },
                    Facility = new SimpleFacilityDto()
                    {
                        AirConditioner = x.Facilities.Any(f => f == Facility.AirConditioner),
                        Kitchen = x.Facilities.Any(f => f == Facility.Kitchen),
                        WashingMachine = x.Facilities.Any(f => f == Facility.WashMachine),
                        Wifi = x.Facilities.Any(f => f == Facility.Wifi),
                    },
                    HouseType = x.Category.Category.ToString() + x.Category.HouseType.ToString() + x.Category.RoomCategory.ToString(),
                    Picture = x.Picture.Select(p => p.ConvertToBase64String()),
                    Price = new PriceDto()
                    {
                        Discount = new DiscountDto()
                        {
                            Month = x.Price.Discount?.Month ?? 100,
                            Week = x.Price.Discount?.Week ?? 100
                        },
                        Fee = new FeeDto()
                        {
                            CleanFee = x.Price.Fee?.CleanFee,
                            ServiceFee = x.Price.Fee?.ServiceFee,
                            TaxFee = x.Price.Fee?.TaxFee,
                        },
                        Origin = x.Price.PerNight,
                        SweetPrice = x.Price.PerWeekNight
                    },
                    Space = new SpaceDto()
                    {
                        Bathroom = x.Space.Count(s => s.SpaceType == SpaceType.Bath),
                        Bed = x.Space.Where(s => s.SpaceType == SpaceType.Bedroom).SelectMany(s => s.BedroomDetails).Sum(b => b.BedCount),
                        CustomerNumber = x.CustomerNumber,
                        Bedroom = x.Space.Count(s => s.SpaceType == SpaceType.Bedroom)
                    },
                    Title = x.Title,
                };
                var wishList = x.WishList.FirstOrDefault(w => w.Houses.Contains(x.Id));
                if (wishList != null)
                {
                    simpleHouseDto.WishList = new WishListDto()
                    {
                        Cover = wishList.Cover.ConvertToBase64String(),
                        Houses = wishList.Houses,
                        Id = wishList.Id,
                        Name = wishList.Name
                    };
                }

                return simpleHouseDto;
            });
        }

        private static IEnumerable<DateTime> GetDateRange(DateTime start, DateTime end)
        {
            var dateRange = new List<DateTime>();
            for (var dt = start; dt < end; dt = dt.AddDays(1))
            {
                dateRange.Add(dt);
            }

            return dateRange;
        }

        private static SpaceDto ConvertToSpaceDto(House house)
        {
            var spaceDto = new SpaceDto() {CustomerNumber = house.CustomerNumber};
            var houseSpaces = house.Spaces;
            if (houseSpaces == null) return spaceDto;

            spaceDto.Bathroom = houseSpaces.Count(x => x.SpaceType == SpaceType.Bath);
            spaceDto.Bedroom = houseSpaces.Count(x => x.SpaceType == SpaceType.Bedroom);
            spaceDto.Bed = houseSpaces.Where(s => s.SpaceType == SpaceType.Bedroom).SelectMany(s => s.BedroomDetails).Sum(b => b.BedCount);
            return spaceDto;
        }
    }
}