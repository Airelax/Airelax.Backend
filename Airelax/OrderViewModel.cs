using Airelax.Domain.Houses.Price;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airelax
{
    public class OrderViewModel
    {
        public decimal PerNight { get; set; }
        public decimal? PerWeekNight { get; set; }
        public decimal CleanFee { get; set; }
        public decimal ServiceFee { get; set; }
        public decimal TaxFee { get; set; }
        //public decimal TotalPerNight { get; set; }
        public int CommentCount { get; set; }
        public double StarTotal { get; set; }

    }
}
