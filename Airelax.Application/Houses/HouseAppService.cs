using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Airelax.Application.Account;
using Airelax.Application.Helpers;
using Airelax.Application.Houses.Dtos.Request;
using Airelax.Application.Houses.Dtos.Response;
using Airelax.Domain.Comments;
using Airelax.Domain.DomainObject;
using Airelax.Domain.Houses;
using Airelax.Domain.Houses.Defines;
using Airelax.Domain.Houses.Defines.Spaces;
using Airelax.Domain.Houses.Price;
using Airelax.Domain.Houses.Specifications;
using Airelax.Domain.RepositoryInterface;
using Airelax.Infrastructure.Map.Abstractions;
using Airelax.Infrastructure.Map.Responses;
using AutoMapper;
using Lazcat.Infrastructure.DependencyInjection;
using Lazcat.Infrastructure.ExceptionHandlers;
using Lazcat.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Airelax.Application.Houses
{
    [DependencyInjection(typeof(IHouseAppService))]
    public class HouseAppService : IHouseAppService
    {
        private readonly IGeocodingService _geocodingService;
        private readonly IHouseRepository _houseRepository;
        private readonly IMapper _mapper;
        private readonly ICommentsRepository _commentsRepository;
        private readonly IMemberRepository _memberRepository;
        public const int PAGE_COUNT = 30;

        public HouseAppService(
            IHouseRepository houseRepository,
            IMemberRepository memberRepository,
            IGeocodingService geocodingService,
            IMapper mapper,
            ICommentsRepository commentsRepository)
        {
            _houseRepository = houseRepository;
            _memberRepository = memberRepository;
            _geocodingService = geocodingService;
            _mapper = mapper;
            _commentsRepository = commentsRepository;
        }

        public async Task<SearchHousesResponse> Search(SearchInput input)
        {
            Check.CheckNull(input);
            //todo
            //var geocodingInfo = await _geocodingService.GetGeocodingInfo(input.Location);
            var geocodingInfo = new GeocodingInfo
            {
                Bounds = new CoordinateRange
                {
                    Northeast = new Coordinate(25.2103038, 121.6659421),
                    SouthWest = new Coordinate(24.9605084, 121.4570603)
                },
                Location = new Coordinate(25.0329636, 121.5654268),
                Viewport = new CoordinateRange
                {
                    Northeast = new Coordinate(25.2103038, 121.6659421),
                    SouthWest = new Coordinate(24.9605084, 121.4570603)
                }
            };

            if (geocodingInfo == null) throw ExceptionBuilder.Build(HttpStatusCode.BadRequest, "找不到地址");

            var searchHousesResponse = new SearchHousesResponse
            {
                LocationInfo = new LocationInfoDto
                {
                    Center = _mapper.Map<Coordinate, CoordinateDto>(geocodingInfo.Location)
                }
            };

            var specification = GetSpecification(input, geocodingInfo);

            var sNow = DateTime.Now;
            Console.WriteLine(sNow);
            var houses = await GetHousesAsync(specification, input.Page);
            var total = await _houseRepository.GetSatisfyFromAsync(specification).CountAsync();

            var dateTime = DateTime.Now;
            Console.WriteLine(dateTime);
            Console.WriteLine("cost" + (dateTime - sNow));


            if (houses.IsNullOrEmpty())
                return searchHousesResponse;

            var results = GetSearchHouses(houses);
            var simpleHouseDtos = ConvertToSimpleHouseDtos(results);
            searchHousesResponse.Houses = simpleHouseDtos;

            searchHousesResponse.Total = total;
            return searchHousesResponse;
        }

        public async Task<HouseDto> GetHouse(string id)
        {
            var house = await _houseRepository.GetAsync(x => x.Id == id);
            if (house == null) throw ExceptionBuilder.Build(HttpStatusCode.BadRequest, $"House Id : {id} does not match any house");
            var member = await _memberRepository.GetAsync(x => x.Id == house.OwnerId);
            if (member == null) throw ExceptionBuilder.Build(HttpStatusCode.BadRequest, "House exist but member has been deleted");
            var houseComments = (await _commentsRepository.GetAll().Where(x => x.HouseId == house.Id)?.ToListAsync()).GroupBy(x => x.HouseId).FirstOrDefault()?.ToList();


            var houseDto = new HouseDto
            {
                Id = house.Id,
                Title = house.Title,
                CancelPolicy = (int)house.Policy.CancelPolicy,
                Pictures = house.Photos?.Select(x => x.Image) ?? new List<string>(),
                Space = ConvertToSpaceDto(house),
                BedroomDetail = ConvertToBedroomDetailDtos(house),
                Description = ConvertToDescriptionDto(house.HouseDescription),
                Facility = ConvertToFacilityDto(house),
                Honor = new List<HonorDto>(),
                Comments = ConvertToCommentDtos(houseComments),
                HouseRule = ConvertToHouseRuleDto(house.HouseRule, house.Policy),
                LocationDto = ConvertToLocationDto(house.HouseLocation),
                Owner = new OwnerDto
                {
                    Name = member.Name,
                    Id = member.Id,
                    RegisterTime = member.RegisterTime,
                    About = member.MemberInfo.About,
                    IsVerified = member.IsEmailVerified,
                    Cover = member.Cover
                },
                Rank = ConvertToRankDto(houseComments),
                WishList = new WishListDto(),
                Price = ConvertToPriceDto(house.HousePrice)
            };
            return houseDto;
        }

        private Task<List<House>> GetHousesAsync(Specification<House> specification, int page)
        {
            return _houseRepository.GetSatisfyFromAsync(specification)
                .OrderByDescending(x => x.CreateTime)
                .Skip((page - 1) * PAGE_COUNT).Take(PAGE_COUNT)
                .ToListAsync();
        }

        private static RankDto ConvertToRankDto(IReadOnlyCollection<HouseCommentObject> houseComments)
        {
            return houseComments.IsNullOrEmpty()
                ? new RankDto()
                : new RankDto()
                {
                    Star = houseComments.Average(x => x.Stars.Total),
                    AccuracyScore = houseComments.Average(x => x.Stars.AccuracyScore),
                    CheapPriceScore = houseComments.Average(x => x.Stars.CheapScore),
                    CleanScore = houseComments.Average(x => x.Stars.CleanScore),
                    CommunicationScore = houseComments.Average(x => x.Stars.CleanScore),
                    ExperienceScore = houseComments.Average(x => x.Stars.ExperienceScore),
                    LocationScore = houseComments.Average(x => x.Stars.LocationScore)
                };
        }

        private static IEnumerable<CommentDto> ConvertToCommentDtos(IReadOnlyCollection<HouseCommentObject> houseComments)
        {
            return houseComments.IsNullOrEmpty()
                ? new List<CommentDto>()
                : houseComments.Select(c => new CommentDto()
                {
                    AuthorId = c.AuthorId,
                    Content = c.Comment.Content,
                    Date = c.Comment.CommentTime.ToString("yyyy-MM-dd"),
                    Name = c.AuthorName
                });
        }

        private static Specification<House> GetSpecification(SearchInput input, GeocodingInfo geocodingInfo)
        {
            Specification<House> specification = new InRangeLocationSpecification(geocodingInfo.Bounds.SouthWest, geocodingInfo.Bounds.Northeast);
            var customerNumberSpecification = new MaxCustomerNumberSpecification(input.CustomerNumber);
            specification = specification.And(customerNumberSpecification);

            if (!input.Checkin.HasValue || !input.Checkout.HasValue) return specification;
            var dateRange = DateTimeHelper.GetDateRange(input.Checkin.Value, input.Checkout.Value);
            var availableDateSpecification = new AvailableDateSpecification(dateRange);
            specification = specification.And(availableDateSpecification);

            return specification;
        }

        private static IEnumerable<SearchHouse> GetSearchHouses(IEnumerable<House> houses)
        {
            return houses.Select(x =>
            {
                var simpleComment = new SearchHouseComment
                {
                    Number = x.Comments?.Count ?? 0
                };
                if (!x.Comments.IsNullOrEmpty()) simpleComment.Stars = Math.Round(x.Comments?.Average(c => c.Star?.Total ?? 0) ?? 0, 1);

                var simpleHouse = new SearchHouse
                {
                    Id = x.Id,
                    Pictures = x.Photos,
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
        }

        private static IEnumerable<SimpleHouseDto> ConvertToSimpleHouseDtos(IEnumerable<SearchHouse> results)
        {
            return results.Select(x =>
            {
                var simpleHouseDto = new SimpleHouseDto
                {
                    Id = x.Id,
                    Address = $"{x.Location.Town ?? string.Empty}",
                    Comment = ConvertToSimpleCommentDto(x.Comment),
                    Facility = ConvertToSimpleFacilityDto(x.Facilities),
                    HouseType = x.Category?.Category.ToString(),
                    Picture = x.Pictures?.Select(p => p.Image) ?? new List<string>(),
                    Price = ConvertToPriceDto(x.Price),
                    Space = ConvertToSimpleSpaceDto(x),
                    Title = x.Title
                };
                SetWishWist(x, simpleHouseDto);

                return simpleHouseDto;
            });
        }

        private static void SetWishWist(SearchHouse x, SimpleHouseDto simpleHouseDto)
        {
            var wishList = x.WishList?.FirstOrDefault(w => w.Houses.Contains(x.Id));
            if (wishList != null)
                simpleHouseDto.WishList = new WishListDto
                {
                    Cover = wishList.Cover,
                    Houses = wishList.Houses,
                    Name = wishList.Name
                };
        }

        private static SimpleSpaceDto ConvertToSimpleSpaceDto(SearchHouse house)
        {
            var simpleSpaceDto = new SimpleSpaceDto
            {
                CustomerNumber = house.CustomerNumber
            };

            if (house.Space.IsNullOrEmpty()) return simpleSpaceDto;

            simpleSpaceDto.Bathroom = house.Space.Count(s => s.SpaceType == SpaceType.Bath);
            var bedroomDetails = house.Space.Where(s => s.SpaceType == SpaceType.Bedroom).SelectMany(s => s.BedroomDetails).ToList();
            if (!bedroomDetails.IsNullOrEmpty()) simpleSpaceDto.Bed = bedroomDetails.Sum(b => b.BedCount);
            simpleSpaceDto.Bedroom = house.Space.Count(s => s.SpaceType == SpaceType.Bedroom);

            return simpleSpaceDto;
        }

        private static SimpleFacilityDto ConvertToSimpleFacilityDto(IEnumerable<Facility> facilities)
        {
            var facilitiesList = facilities?.ToList();
            if (facilitiesList.IsNullOrEmpty()) return new SimpleFacilityDto();
            return new SimpleFacilityDto
            {
                AirConditioner = facilitiesList.Any(f => f == Facility.AirConditioner),
                Kitchen = facilitiesList.Any(f => f == Facility.Kitchen),
                WashingMachine = facilitiesList.Any(f => f == Facility.WashMachine),
                Wifi = facilitiesList.Any(f => f == Facility.Wifi)
            };
        }

        private static SimpleCommentDto ConvertToSimpleCommentDto(SearchHouseComment comment)
        {
            return new()
            {
                Star = comment?.Stars ?? 0,
                TotalComments = comment?.Number ?? 0
            };
        }

        private static PriceDto ConvertToPriceDto(HousePrice housePrice)
        {
            var price = new PriceDto
            {
                Discount = new DiscountDto(),
                Fee = new FeeDto()
            };
            if (housePrice == null) return price;

            price.Origin = decimal.Round(housePrice.PerNight);
            price.SweetPrice = housePrice.PerWeekNight == null ? price.Origin : decimal.Round(housePrice.PerWeekNight.Value);
            //if (price.Discount != null)
            //{
            //    price.Discount.Month = housePrice.Discount.Month;
            //    price.Discount.Week = housePrice.Discount.Week;
            //}

            if (housePrice.Fee == null) return price;

            price.Fee.CleanFee = decimal.Round(housePrice.Fee.CleanFee);
            price.Fee.ServiceFee = decimal.Round(housePrice.Fee.ServiceFee);
            price.Fee.TaxFee = decimal.Round(housePrice.Fee.TaxFee);
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
                houseRuleDto.Other = houseHouseRule.Other;
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
                : new DescriptionDto
                {
                    HouseDescription = houseHouseDescription.Description,
                    GuestPermission = houseHouseDescription.GuestPermission,
                    Others = houseHouseDescription.Others,
                    SpaceDescription = houseHouseDescription.SpaceDescription
                };
        }

        private static IEnumerable<BedroomDetailDto> ConvertToBedroomDetailDtos(House house)
        {
            return house.Spaces?.SelectMany(x => x.BedroomDetails).Select(x => new BedroomDetailDto
            {
                BedCount = x.BedCount,
                BedType = x.BedType.ToString()
            }) ?? new List<BedroomDetailDto>();
        }

        private static FacilityDto ConvertToFacilityDto(House house)
        {
            return new()
            {
                Provide = house.ProvideFacilities?.Select(x => (int)x),
                NotProvide = house.NotProvideFacilities?.Select(x => (int)x)
            };
        }


        private static SimpleSpaceDto ConvertToSpaceDto(House house)
        {
            var spaceDto = new SimpleSpaceDto { CustomerNumber = house.CustomerNumber };
            var houseSpaces = house.Spaces;
            if (houseSpaces == null) return spaceDto;

            spaceDto.Bathroom = houseSpaces.Count(x => x.SpaceType == SpaceType.Bath);
            spaceDto.Bedroom = houseSpaces.Count(x => x.SpaceType == SpaceType.Bedroom);
            spaceDto.Bed = houseSpaces.Where(s => s.SpaceType == SpaceType.Bedroom).SelectMany(s => s.BedroomDetails).Sum(b => b.BedCount);
            return spaceDto;
        }
    }
}