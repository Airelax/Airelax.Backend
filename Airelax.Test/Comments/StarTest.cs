using System.Collections.Generic;
using Airelax.Domain.Comments;
using Shouldly;
using Xunit;

namespace Airelax.Test.Comments
{
    public class StarTest
    {
        [Theory]
        [MemberData(nameof(GetStarData))]
        public void Total_Star_Test(Star star, double expected)
        {
            star.Total.ShouldBe(expected);
        }

        public static IEnumerable<object[]> GetStarData()
        {
            yield return new object[]
            {
                new Star("1", 5, 5, 5, 5, 5, 5),
                5.0
            };
            yield return new object[]
            {
                new Star("1", 5, 3, 5, 5, 3, 5),
                4.3
            };
            yield return new object[]
            {
                new Star("1", 1, 4, 5, 5, 4, 5),
                4.0
            };
        }
    }
}