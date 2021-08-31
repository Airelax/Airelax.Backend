namespace Airelax.Application.Houses.Dtos.Response
{
    public class LocationInfoDto
    {
        public CoordinateDto Center { get; set; }
        public CoordinateRangeDto Boundary { get; set; }
    }
}