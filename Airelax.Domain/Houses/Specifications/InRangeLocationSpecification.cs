﻿using System;
using System.Linq.Expressions;
using Airelax.Domain.DomainObject;
using Lazcat.Infrastructure.Map.Responses;

namespace Airelax.Domain.Houses.Specifications
{
    public class InRangeLocationSpecification : ExpressionSpecification<House>
    {
        private readonly Coordinate _southwest;
        private readonly Coordinate _northeast;


        public InRangeLocationSpecification(Coordinate southwest, Coordinate northeast)
        {
            _southwest = southwest;
            _northeast = northeast;
        }

        public override Expression<Func<House, bool>> ToExpression()
        {
            return house => house.HouseLocation.Longitude >= _southwest.Longitude &&
                            house.HouseLocation.Longitude <= _northeast.Longitude &&
                            house.HouseLocation.Latitude >= _southwest.Latitude &&
                            house.HouseLocation.Latitude <= _northeast.Latitude;
        }
    }
}