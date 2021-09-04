using Airelax.Domain.Orders.Define;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Airelax
{
    public class OrdersInput
    {
        //Order
        public string CustomerId { get; set; }
        [Required]
        public string HouseId { get; set; }

        //OrderDetail
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Adult { get; set; }
        public int Baby { get; set; }
        public int Child { get; set; }
    }
}
