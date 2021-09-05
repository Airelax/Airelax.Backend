using Airelax.Domain.Houses.Defines;

namespace Airelax.Application.ManageHouses.Request
{
    public class HouseCategoryInput
    {
        public Category Category { get; set; }
        public HouseType? HouseType { get; set; }
        public RoomCategory? RoomCategory { get; set; }
    }
}