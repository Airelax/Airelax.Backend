using Airelax.Domain.DomainObject;

namespace Airelax.Domain.Members
{
    public class MemberInfo : Entity<int>
    {
        public string About { get; set; }
        public string Location { get; set; }
    }
}