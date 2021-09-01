using System;
using Airelax.Application.Houses.Dtos.Response;
using Airelax.Domain.Comments;
using Airelax.Domain.Houses;
using Airelax.Domain.Houses.Price;
using Airelax.Domain.Members;
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