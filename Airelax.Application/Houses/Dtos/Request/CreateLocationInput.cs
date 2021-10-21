namespace Airelax.Application.Houses.Dtos.Request
{
    public class CreateLocationInput
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Town { get; set; }
        public string ZipCode { get; set; }
        public string AddressDetail { get; set; }
        public string FullAddress { get; set; }
    }
}