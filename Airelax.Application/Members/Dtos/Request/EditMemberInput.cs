using System;

namespace Airelax.Application.Members.Dtos.Request
{
    public class EditMemberInput
    {
        public string Name { get; set; }
        public int Gender { get; set; }
        //public DateTime Birthday { get; set; }
        public string Country { get; set; }
        public string Zipcode { get; set; }
        public string AddressDetail { get; set; }
        public string Phone { get; set; }
    }
}