namespace Airelax.Application.Houses.Dtos.Response
{
    public class PriceDto
    {
        public decimal Origin { get; set; }
        public decimal SweetPrice { get; set; }
        public FeeDto Fee { get; set; }
        public DiscountDto Discount { get; set; }
    }
}