namespace Airelax.Application.Houses.Dtos.Response
{
    public class HouseRuleDto
    {
        public string CheckinTime { get; set; }
        public string CheckoutTime { get; set; }
        public bool? AllowChild { get; set; }
        public bool? AllowBaby { get; set; }
        public bool? AllowPet { get; set; }
        public bool? AllowSmoke { get; set; }
        public bool? AllowParty { get; set; }
        public decimal CashPledge { get; set; }
        public string Other { get; set; }
    }
}