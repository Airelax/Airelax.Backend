namespace Airelax.Application.WishLists.Dtos.Request
{
    public class UpdateWishListInput : CreateWishListInput
    {
        public int WishId { get; set; }
        public bool IsAdd { get; set; }
    }
}