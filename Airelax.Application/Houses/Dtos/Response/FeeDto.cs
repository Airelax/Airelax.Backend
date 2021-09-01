namespace Airelax.Application.Houses.Dtos.Response
{
    public class FeeDto
    {
        public decimal CleanFee { get; set; } = 0;
        public decimal ServiceFee { get; set; } = 0;
        public decimal TaxFee { get; set; } = 0;
    }
}