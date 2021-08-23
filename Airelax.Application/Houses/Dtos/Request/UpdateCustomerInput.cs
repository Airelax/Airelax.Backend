using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airelax.Application.Houses.Dtos.Request
{
    public class UpdateCustomerInput
    {
        public int CustomerNumber { get; set; }
        public int BedCount { get; set; }
        public int Bedroom { get; set; }
        public int Bath { get; set; }
    }
}