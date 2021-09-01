namespace Airelax.Application.Houses.Dtos.Response
{
    public class DiscountDto
    {
        public int Week { get; set; } = 100;
        public int Month { get; set; } = 100;
        public int EarlyBird { get; set; }
        public int NightBird { get; set; }
    }
}