using Airelax.Domain.DomainObject;

namespace Airelax.Domain.Members
{
    public class EmergencyContact : Entity<string>
    {
        public string Name { get; set; }
        public string Phone { get; set; }

        public EmergencyContact(string id)
        {
            Id = id;
        }
    }
}