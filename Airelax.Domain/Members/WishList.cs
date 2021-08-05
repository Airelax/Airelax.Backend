using System.Collections.Generic;
using Airelax.Domain.DomainObject;

namespace Airelax.Domain.Members
{
    public class WishList : AggregateRoot<int>
    {
        public int MemberId { get; set; }
        public string Name { get; set; }
        public byte[] Cover { get; set; }
        public List<int> Houses { get; set; }

        public WishList(int memberId)
        {
            MemberId = memberId;
        }
    }
}