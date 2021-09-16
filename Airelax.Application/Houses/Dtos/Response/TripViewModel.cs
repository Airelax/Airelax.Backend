using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airelax.Application.Houses.Dtos.Response
{
    public class TripViewModel
    {
        public string OrderId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Image { get; set; }
        public string Town { get; set; }
        public string Title { get; set; }
    }

    public class TripViewModels
    {
        public IEnumerable<TripViewModel> FinishedTrips { get; set; }
        public IEnumerable<TripViewModel> UpcomingTrips { get; set; }
    }
}
