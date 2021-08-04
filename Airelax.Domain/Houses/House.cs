using System;
using System.Collections.Generic;
using Airelax.Domain.Comments;
using Airelax.Domain.DomainObject;
using Airelax.Domain.Houses.Defines;
using Airelax.Domain.Houses.Price;
using Airelax.Domain.Orders;

namespace Airelax.Domain.Houses
{
    public class House : AggregateRoot<int>
    {
        public string Title { get; set; }
        public HouseStatus Status { get; set; }
        public CreateState CreateState { get; set; }
        public int CustomerNumber { get; set; }
        public int OwnerId { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime LastModifyTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}