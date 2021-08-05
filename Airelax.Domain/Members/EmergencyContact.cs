using Airelax.Domain.DomainObject;

namespace Airelax.Domain.Members
{
    public class EmergencyContact : Entity<int>
    {
        public string Name { get; set; }
        public string Phone { get; set; }

        public EmergencyContact(int id)
        {
            Id = id;
        }
    }
}