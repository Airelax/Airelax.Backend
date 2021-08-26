using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airelax.Application.Houses.Dtos.Request.ManageHouse
{
    public class HouseAddressInput
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Town { get; set; }
        public string ZipCode { get; set; }
        public string Address { get; set; }
    }
}
