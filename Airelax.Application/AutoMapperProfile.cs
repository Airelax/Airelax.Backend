using Airelax.Application.Houses.Dtos.Response;
using Airelax.Infrastructure.Map.Responses;
using AutoMapper;

namespace Airelax.Application
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Coordinate, CoordinateDto>();
            CreateMap<CoordinateRange, CoordinateRangeDto>();
        }
    }
}