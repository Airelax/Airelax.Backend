using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airelax.Domain.Houses;
using Airelax.Domain.Messages;

namespace Airelax.Application.Messages.Request
{
    public class CreateMessageInput
    {
        public string MemberOneId { get; set; }
        public string MemberTwoId { get; set; }
        public List<MessageContent> Contents { get; set; }
        public string HouseId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int MemberOneStatus { get; set; }
        public int MemberTwoStatus { get; set; }
    }
}
