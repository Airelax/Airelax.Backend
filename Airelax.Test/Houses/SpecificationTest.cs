using System;
using System.Collections.Generic;
using Airelax.Domain.Houses;
using Airelax.Domain.Houses.Specifications;
using Airelax.Infrastructure.Map.Responses;
using Shouldly;
using Xunit;

namespace Airelax.Test.Houses
{
    public class SpecificationTest
    {
        private readonly House _house;

        public SpecificationTest()
        {
            _house = new House("123")
            {
                CustomerNumber = 6,
                ReservationDates = new List<DateTime>
                {
                    new(2021, 8, 1),
                    new(2021, 8, 2),
                    new(2021, 8, 3),
                    new(2021, 9, 15),
                    new(2021, 9, 30),
                    new(2022, 3, 15),
                    new(2022, 7, 20)
                }
            };

            _house.HouseLocation = new HouseLocation(_house.Id)
            {
                Latitude = 23.857246614025858,
                Longitude = 120.91596310005775
            };
        }

        [Theory]
        [MemberData(nameof(AvailableDateSpecificationTestData))]
        public void AvailableDateSpecification_Test(AvailableDateSpecification availableDateSpecification, bool expect)
        {
            availableDateSpecification.IsSatisfy(_house).ShouldBe(expect);
        }

        [Theory]
        [MemberData(nameof(InRangeLocationSpecificationTestData))]
        public void InRangeLocationSpecification_Test(InRangeLocationSpecification inRangeLocationSpecification, bool expect)
        {
            inRangeLocationSpecification.IsSatisfy(_house).ShouldBe(expect);
        }

        [Theory]
        [MemberData(nameof(MaxCustomerNumberSpecificationTestData))]
        public void MaxCustomerNumberSpecification_Test(MaxCustomerNumberSpecification maxCustomerNumberSpecification, bool expect)
        {
            maxCustomerNumberSpecification.IsSatisfy(_house).ShouldBe(expect);
        }

        public static IEnumerable<object[]> AvailableDateSpecificationTestData()
        {
            return new List<object[]>
            {
                new object[]
                {
                    new AvailableDateSpecification(new List<DateTime>
                    {
                        new(2021, 8, 1),
                        new(2021, 8, 2),
                        new(2021, 8, 4),
                        new(2021, 8, 5)
                    }),
                    false
                },
                new object[]
                {
                    new AvailableDateSpecification(new List<DateTime>
                    {
                        new(2021, 7, 1),
                        new(2021, 7, 2)
                    }),
                    true
                },
                new object[]
                {
                    new AvailableDateSpecification(new List<DateTime>
                    {
                        new(2022, 3, 15),
                        new(2022, 3, 16)
                    }),
                    false
                }
            };
        }

        public static IEnumerable<object[]> InRangeLocationSpecificationTestData()
        {
            return new List<object[]>
            {
                new object[]
                {
                    new InRangeLocationSpecification(new Coordinate(23.86102543, 120), new Coordinate(22.2145487, 121.45721243)),
                    false
                },
                new object[]
                {
                    new InRangeLocationSpecification(new Coordinate(23.850421236, 120.90115442), new Coordinate(23.85222143, 121.045721243)),
                    false
                },
                new object[]
                {
                    new InRangeLocationSpecification(new Coordinate(23.850421236, 120.90115442), new Coordinate(23.89222143, 121.045721243)),
                    true
                },
                new object[]
                {
                    new InRangeLocationSpecification(new Coordinate(23, 120), new Coordinate(24, 122)),
                    true
                }
            };
        }

        public static IEnumerable<object[]> MaxCustomerNumberSpecificationTestData()
        {
            return new List<object[]>
            {
                new object[]
                {
                    new MaxCustomerNumberSpecification(10), false
                },
                new object[]
                {
                    new MaxCustomerNumberSpecification(8), false
                },
                new object[]
                {
                    new MaxCustomerNumberSpecification(5), true
                },
                new object[]
                {
                    new MaxCustomerNumberSpecification(2), true
                }
            };
        }
    }
}