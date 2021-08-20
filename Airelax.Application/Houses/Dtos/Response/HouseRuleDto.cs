using System;

namespace Airelax.Application.Houses.Dtos.Response
{
    public class HouseRuleDto
    {
        public DateTime CheckinTime { get; set; }
        public DateTime CheckoutTime { get; set; }
        public bool? AllowChild { get; set; }
        public bool? AllowBaby { get; set; }
        public bool? AllowPet { get; set; }
        public bool? AllowSmoke { get; set; }
        public bool? AllowParty { get; set; }
        public decimal CashPledge { get; set; }
        public string Other { get; set; }
    }

    //public class ManageVM {
    //    public HouseRuleDto houseRule { get; set; }
    //    public PolicyDto policy { get; set; }
    //}
}