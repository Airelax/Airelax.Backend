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

        public HouseCategory HouseCategory { get; set; }
        public HouseDescription HouseDescription { get; set; }
        public HouseLocation HouseLocation { get; set; }
        public HouseRule HouseRule { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public Policy Policy { get; set; }
        public ReservationRule ReservationRule { get; set; }
        public ICollection<Space> Spaces { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Comment> Comments { get; set; }
        //todo
        //public HousePrice HousePrice { get; set; }
    }
}