using Airelax.Domain.Members.Defines;

namespace Airelax.Application.Members.Dtos.Response
{
    public class MemberViewModel
    {
        public string MemberId { get; set; }
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