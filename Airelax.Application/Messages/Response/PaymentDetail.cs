using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airelax.Application.Messages.Response
{
    public class PaymentDetail
    {
        public decimal CleanFee { get; set; }
        public decimal ServiceFee { get; set; }
        public decimal TaxFee { get; set; }
    }
}
