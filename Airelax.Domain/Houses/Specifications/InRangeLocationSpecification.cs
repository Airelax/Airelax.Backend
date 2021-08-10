using System;
using System.Linq.Expressions;
using Airelax.Domain.DomainObject;

namespace Airelax.Domain.Houses.Specifications
{
    public class InRangeLocationSpecification : ExpressionSpecification<House>
    {
        private readonly (double lat, double lng) _startCoordinate;
        private readonly (double lat, double lng) _endCoordinate;


        public InRangeLocationSpecification((double lat, double lng) startCoordinate, (double lat, double lng) endCoordinate)
        {
            _startCoordinate = startCoordinate;
            _endCoordinate = endCoordinate;
        }

        public override Expression<Func<House, bool>> ToExpression()
        {
            return house => house.HouseLocation.Longitude >= _startCoordinate.lng &&
                            house.HouseLocation.Longitude <= _endCoordinate.lng &&
                            house.HouseLocation.Latitude >= _startCoordinate.lat &&
                            house.HouseLocation.Latitude <= _endCoordinate.lat;
        }
    }
}