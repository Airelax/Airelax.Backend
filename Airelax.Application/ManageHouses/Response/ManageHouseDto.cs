using System.Collections.Generic;
using Airelax.Application.Houses.Dtos.Response;

namespace Airelax.Application.ManageHouses.Response
{
    public class ManageHouseDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<string> Pictures { get; set; }
        public DescriptionDto Description { get; set; }
        public int Status { get; set; }
        public List<int> ProvideFacilities { get; set; }
        public List<int> NotProvideFacilities { get; set; }
        public AddressDto Address { get; set; }
        public HouseCategoryVM HouseCategory { get; set; }
        public int CustomerNumber { get; set; }
        public string Origin { get; set; }
        public string SweetPrice { get; set; }
        public string Fee { get; set; }
        public string WeekDiscount { get; set; }
        public string MonthDiscount { get; set; }
        public int Cancel { get; set; }
        public bool InstanceBooking { get; set; }
        public string CheckinTime { get; set; }
        public string CheckoutTime { get; set; }
        public string CashPledge { get; set; }
        public HouseRuleDto HouseRule { get; set; }
        public string SpaceBed { get; set; }
    }

    public class SpaceBedVM
    {
        public SpaceVM SpaceVM { get; set; }
        public BedroomDetailVM BedroomDetailVM { get; set; }
    }

    public class SpaceVM
    {
        public string Id { get; set; }
        public string HouseId { get; set; }
        public int SpaceType { get; set; }
        public bool IsShared { get; set; }
    }

    public class BedroomDetailVM
    {
        public string SpaceId { get; set; }
        public int? BedType { get; set; }
        public int? BedCount { get; set; }
        public bool? HasIndependentBath { get; set; }
    }

    public class HouseCategoryVM
    {
        public int? Category { get; set; }
        public int? HouseType { get; set; }
        public int? RoomCategory { get; set; }
    }
}