namespace Airelax.Application.ManageHouses.Request
{
    public class HousePriceInput
    {
        public decimal Origin { get; set; }
        public decimal? SweetPrice { get; set; }
        public decimal? CashPledge { get; set; }
        public decimal CleanFee { get; set; }
        public decimal WeekDiscount { get; set; }
        public decimal MonthDiscount { get; set; }

    }
}