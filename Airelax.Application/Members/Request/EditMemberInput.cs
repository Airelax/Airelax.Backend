using Airelax.Domain.Members.Defines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airelax.Application.Members.Request
{
    public class EditMemberInput
    {
        public string Name { get; set; }
        public int Gender { get; set; }
        public string Birthday { get; set; }
        public string Country { get; set; }
        public string Zipcode { get; set; }
        public string AddressDetail { get; set; }
        public string Phone { get; set; }

    }
}
