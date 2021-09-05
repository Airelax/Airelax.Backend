using Airelax.Domain.Houses.Defines;

namespace Airelax.Application.Houses.Dtos.Response
{
    public class MyHouseViewModel
    {
        public string HouseId { get; set; }
        public string Title { get; set; }
        public HouseStatus HouseStatus { get; set; }
        public CreateState CreateState { get; set; }
        public bool CanRealTime { get; set; }
        public string Location { get; set; }
        public string LastReservationTime { get; set; }
    }
}