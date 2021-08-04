﻿using System.Buffers.Text;
using System.Collections.Generic;
using Airelax.Domain.DomainObject;
using Airelax.Domain.Houses;

namespace Airelax.Domain.Members
{
    public class WishList: AggregateRoot<int>
    {
        public int MemberId { get; set; }
        public string Name { get; set; }
        public byte[] Cover { get; set; }
        public List<int> Houses { get; set; }
    }
}