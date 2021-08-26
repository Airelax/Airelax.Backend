using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airelax.Application.Houses.Dtos.Request.ManageHouse
{
    public class HousePriceInput
    {
        public decimal Origin { get; set; }
        public decimal? SweetPrice { get; set; }
        public decimal? CashPledge { get; set; }
    }
}
