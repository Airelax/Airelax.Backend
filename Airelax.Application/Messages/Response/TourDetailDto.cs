using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airelax.Application.Messages.Response
{
    public class TourDetailDto
    {
        public string Title { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Town { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
