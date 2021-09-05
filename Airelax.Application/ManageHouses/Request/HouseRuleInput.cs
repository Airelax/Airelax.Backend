namespace Airelax.Application.ManageHouses.Request
{
    public class HouseRuleInput
    {
        public bool? AllowChild { get; set; }
        public bool? AllowBaby { get; set; }
        public bool? AllowPet { get; set; }
        public bool? AllowSmoke { get; set; }
        public bool? AllowParty { get; set; }
    }
}