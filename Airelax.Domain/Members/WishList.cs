using System.Buffers.Text;
using System.Collections.Generic;
using Airelax.Domain.DomainObject;

namespace Airelax.Domain.Members
{
    public class WishList: AggregateRoot<int>
    {
        public int MemberId { get; set; }
        public byte[] Cover { get; set; }
        public IList<int> Houses { get; set; }
    }
}