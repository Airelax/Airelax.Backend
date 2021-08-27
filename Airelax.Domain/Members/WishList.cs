using System.Collections.Generic;
using Airelax.Domain.DomainObject;

namespace Airelax.Domain.Members
{
    public class WishList : AggregateRoot<int>
    {
        public string MemberId { get; set; }
        public string Name { get; set; }
        public string Cover { get; set; }
        public List<string> Houses { get; set; }

        public WishList(string memberId)
        {
            MemberId = memberId;
        }
    }
}