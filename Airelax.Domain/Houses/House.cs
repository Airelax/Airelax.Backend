using System;
using Airelax.Domain.DomainObject;
using Airelax.Domain.Houses.Defines;

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


        public House()
        {
            Status = HouseStatus.CancelPublish;
            CreateState = CreateState.Building;
            CustomerNumber = 1;
            CreateTime = DateTime.Now;
            IsDeleted = false;
        }
    }
}