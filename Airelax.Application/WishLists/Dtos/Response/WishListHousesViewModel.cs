using Airelax.Application.Houses.Dtos.Response;
using Airelax.Domain.Houses;

namespace Airelax.Application.WishLists.Dtos.Response
{
    public class WishListHousesViewModel
    {
        public string Title { get; set; }
        public int CustomerNumber { get; set; }

        public string Location { get; set; }
        public string HouseCategory { get; set; }

        public SimpleCommentDto Comment { get; set; }

        public decimal? PricePerNight { get; set; }

        public string Photo { get; set; }

        public WishListHousesViewModel()
        {
            Comment = new SimpleCommentDto();
        }
    }
}