using System.Collections.Generic;

namespace Airelax
{
    public interface IWishListService
    {
        void CreateWishList(string memberId, string WishName, string HouseId);
        void DeleteWishList(int WishId);
        IEnumerable<WishListViewModel> GetWishList(string memberId);
        void UpdateWishList(string memberId, string HouseId, int WishId);
    }
}