using System;
using Airelax.Domain.DomainObject;

namespace Airelax.Domain.Houses
{
    public class ReservationRule: Entity<int>
    {
        public int MinNight { get; set; }
        public int MaxNight { get; set; }
        public DateTime LastReservationTime { get; set; }
        public int PrepareTime { get; set; }
        public int AvailableTime { get; set; }
        public DayOfWeek RejectDate { get; set; }
    }
}