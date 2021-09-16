using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Airelax.Domain.Houses;
using Airelax.Domain.Houses.Defines;

namespace Airelax.Application.Houses.Dtos.Request
{
    public class SearchInput
    {
        [Required] public string Location { get; set; }
        public DateTime? Checkin { get; set; }
        public DateTime? Checkout { get; set; }
        public int CustomerNumber { get; set; } = 1;
        public int Page { get; set; } = 1;
        public bool FreeCancel { get; set; } = false;
        public string RoomCategories { get; set; }
        public string Facilities { get; set; }
        public string Categories { get; set; }
        public string HouseTypes { get; set; }
        public bool AllowPet { get; set; } = false;
        public bool AllowSmoke { get; set; } = false;
        public decimal LowPrice { get; set; } = 0;
        public decimal HighPrice { get; set; } = 50000;
        public bool Realtime { get; set; } = false;
        public int BedCount { get; set; } = 0;
        public int BedroomCount { get; set; } = 0;
        public int BathroomCount { get; set; } = 0;
    }
}