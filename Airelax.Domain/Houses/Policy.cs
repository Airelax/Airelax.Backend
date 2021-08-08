using System;
using Airelax.Domain.DomainObject;
using Airelax.Domain.Houses.Defines;

namespace Airelax.Domain.Houses
{
    public class Policy: Entity<int>
    {
        public bool CanRealTime { get; set; }
        public CancelPolicy CancelPolicy { get; set; }
        public DateTime CheckinTime { get; set; }
        public DateTime CheckoutTime { get; set; }
        public decimal CashPledge { get; set; }
    }
}