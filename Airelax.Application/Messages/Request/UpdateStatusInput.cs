using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airelax.Application.Messages.Request
{
    public class UpdateStatusInput
    {
        public string MemberId { get; set; }
        public string OtherId { get; set; }
    }
}
