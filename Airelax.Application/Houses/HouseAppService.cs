using Airelax.Application.Houses.Dtos.Response;
using Lazcat.Infrastructure.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using Airelax.Application.Houses.Dtos.Request;
using Airelax.Domain.Comments;
using Airelax.Domain.DomainObject;
using Airelax.Domain.Houses;
using Airelax.Domain.Houses.Defines;
using Airelax.Domain.Houses.Defines.Spaces;
using Airelax.Domain.Houses.Price;
using Airelax.Domain.Houses.Specifications;
using Airelax.Domain.Members;
using Microsoft.Extensions.DependencyInjection;
using Airelax.Domain.RepositoryInterface;
using Lazcat.Infrastructure.ExceptionHandlers;
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

        public async Task<HouseDto> GetHouse(int id)
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
                // .Select(x => new
                // {
                //     Id = x.Id,
                //     Picture = x.Photos.Select(p => p.Image),
                //     WishList = x.Member.WishLists,
                //     Location = x.HouseLocation,
                //     Price = x.HousePrice,
                //     Title = x.Title,
                //     Category = x.HouseCategory,
                //     Facilities = x.ProvideFacilities.Intersect(Definition.SimpleFacilities),
                //     CustomerNumber = x.CustomerNumber,
                //     Space = x.Spaces.Where(s => s.SpaceType == SpaceType.Bath || s.SpaceType == SpaceType.Bedroom),
                //     Comment = new
                //     {
                //         Number = x.Comments.Count,
                //         Stars = Math.Round(x.Comments.Average(c => c.Star.Total), 1)
                //     }
                // })
                .AsEnumerable();
            houses = houses.Where(x => specification.IsSatisfy(x));
            return null;
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