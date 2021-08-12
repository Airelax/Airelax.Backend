using System;
using System.ComponentModel.DataAnnotations;

namespace Airelax.Application.Houses.Dtos.Request
{
    public class SearchInput
    {
        [Required] public string Location { get; set; }
        public DateTime? Checkin { get; set; }
        public DateTime? Checkout { get; set; }
        public int CustomerNumber { get; set; } = 1;
        public int Page { get; set; } = 1;
    }
}