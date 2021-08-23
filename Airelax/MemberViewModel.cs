using Airelax.Domain.Members.Defines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airelax
{
    public class MemberViewModel
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public string Birthday { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public int ZipCode { get; set; }
        public string AddressDetail { get; set; }

    }
}
