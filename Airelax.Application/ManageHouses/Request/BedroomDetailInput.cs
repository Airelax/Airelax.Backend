namespace Airelax.Application.ManageHouses.Request
{
    public class BedroomDetailInput
    {
        public string SpaceId { get; set; }
        public int? BedType { get; set; }
        public int? BedCount { get; set; }
        public bool? HasIndependentBath { get; set; }
    }
}