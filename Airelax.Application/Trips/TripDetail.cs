namespace Airelax.Application.Trips
{
    public class TripDetail
    {
        public string Id { get; set; }
        public string Image { get; set; }
        public string Checkin { get; set; }
        public string Checkout { get; set; }
        public string CheckinTime { get; set; }
        public string CheckoutTime { get; set; }
        public decimal Price { get; set; }
        public int Customer { get; set; }
        public int Children { get; set; }
        public int Baby { get; set; }
        public string Address { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public string Title { get; set; }
    }
}