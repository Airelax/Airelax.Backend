using System;
using System.ComponentModel.DataAnnotations;

namespace Airelax.Application.Orders.Request
{
    public class OrdersInput
    {
        //Order
        [Required] public string HouseId { get; set; }
        //OrderDetail
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Adult { get; set; }
        public int Baby { get; set; }
        public int Child { get; set; }
    }
}