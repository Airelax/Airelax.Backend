using Airelax.Domain.DomainObject;

namespace Airelax.Domain.Houses
{
    public class HouseRule:Entity<string>
    {
        public bool? AllowChild { get; set; }
        public bool? AllowBaby { get; set; }
        public bool? AllowPet { get; set; }
        public bool? AllowSmoke { get; set; }
        public bool? AllowParty { get; set; }
        public string Other { get; set; }

        public HouseRule(string id)
        {
            Id = id;
        }
    }
}