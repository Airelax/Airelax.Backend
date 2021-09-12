using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airelax.Application.Messages.Response
{
    public class MessageDto
    {
        public string Id { get; set; }
        public string ConnectString { get; set; }
        public string MemberId { get; set; }
        public string GusetId { get; set; }
        public string Name { get; set; }
        public string Portrait { get; set; }
        public int MemberOneStatus { get; set; }
        public int MemberTwoStatus { get; set; }
        public IEnumerable<string> Pictures { get; set; }
        public decimal Origin { get; set; }
        public PaymentDetail PaymentDetail { get; set; }
        public TourDetailDto TourDetail { get; set; }
        public LandlordDto Landlord { get; set; }
        public List<CommunicationDto> Communications { get; set; }
    }
}
