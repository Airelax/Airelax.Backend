using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airelax.Application.Houses.Dtos.Request;
using Airelax.Application.Houses.Dtos.Response;
using Airelax.Domain.DomainObject;
using Airelax.Domain.Houses;
using Airelax.Domain.Houses.Defines;
using Airelax.Domain.Houses.Defines.Spaces;
using Airelax.Domain.Houses.Specifications;
using Airelax.Domain.RepositoryInterface;
using Lazcat.Infrastructure.DependencyInjection;
using Lazcat.Infrastructure.Map.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Airelax.Application.Houses
{
    [DependencyInjection(typeof(IHouseAppService))]
    public class HouseAppService : IHouseAppService
    {
        private readonly IHouseRepository _houseRepository;
        private readonly IGeocodingService _geocodingService;

        public HouseAppService(IHouseRepository houseRepository, IGeocodingService geocodingService)
        {
            _houseRepository = houseRepository;
            _geocodingService = geocodingService;
        }

        public async Task<HouseDto> GetHouse(string id)
        {
            //using (var context = new AirelaxContext()) 
            //{

            //   return context.Houses.FisrtORDefalut(x => x.id == id);
            //}

            return default;
        }

        public async Task<IEnumerable<SimpleHouseDto>> Search(SearchInput input)
        {
            Check.CheckNull(input);
            var geocodingInfo = await _geocodingService.GetGeocodingInfo(input.Location);

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
                .ToList();

            var results = houses.Where(x => specification.IsSatisfy(x)).Select(x => new SimpleHouse()
            {
                Id = x.Id,
                Picture = x.Photos.Select(p => p.Image),
                WishList = x.Member.WishLists,
                Location = x.HouseLocation,
                Price = x.HousePrice,
                Title = x.Title,
                Category = x.HouseCategory,
                Facilities = x.ProvideFacilities.Intersect(Definition.SimpleFacilities),
                CustomerNumber = x.CustomerNumber,
                Space = x.Spaces.Where(s => s.SpaceType == SpaceType.Bath || s.SpaceType == SpaceType.Bedroom),
                Comment = new SimpleComment()
                {
                    Number = x.Comments.Count,
                    Stars = Math.Round(x.Comments.Average(c => c.Star.Total), 1)
                }
            });

            var simpleHouseDtos = ConvertToSimpleHouseDtos(results);
            return simpleHouseDtos;
        }

        private static IEnumerable<SimpleHouseDto> ConvertToSimpleHouseDtos(IEnumerable<SimpleHouse> results)
        {
            return results.Select(x =>
            {
                var simpleHouseDto = new SimpleHouseDto
                {
                    Id = x.Id,
                    Address = x.Location.Country + x.Location.City + x.Location.Town,
                    Comment = new SimpleCommentDto()
                    {
                        Star = x.Comment.Stars,
                        TotalComments = x.Comment.Number
                    },
                    Facility = new SimpleFacilityDto()
                    {
                        AirConditioner = x.Facilities.Any(f => f == Facility.AirConditioner),
                        Kitchen = x.Facilities.Any(f => f == Facility.Kitchen),
                        WashingMachine = x.Facilities.Any(f => f == Facility.WashMachine),
                        Wifi = x.Facilities.Any(f => f == Facility.Wifi),
                    },
                    HouseType = x.Category.Category.ToString() + x.Category.HouseType.ToString() + x.Category.RoomCategory.ToString(),
                    Picture = x.Picture.Select(x => x.ConvertToBase64String()),
                    Price = new PriceDto()
                    {
                        Discount = new DiscountDto()
                        {
                            Month = x.Price.Discount.Month,
                            Week = x.Price.Discount.Week
                        },
                        Fee = new FeeDto()
                        {
                            CleanFee = x.Price.Fee.CleanFee,
                            ServiceFee = x.Price.Fee.ServiceFee,
                            TaxFee = x.Price.Fee.TaxFee,
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
    }
}