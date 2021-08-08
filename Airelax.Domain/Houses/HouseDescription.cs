using Airelax.Domain.DomainObject;
using Airelax.Domain.Houses.Defines;
using SpanJson;

namespace Airelax.Domain.Houses
{
    public class HouseDescription : Entity<string>
    {
        public HouseHighlight? HouseHighlight { get; set; }
        public string Description { get; set; }
        public string SpaceDescription { get; set; }
        public string GuestPermission { get; set; }
        public string Others { get; set; }
        public HouseDescription(string id)
        {
            Id = id;
        }
    }
}