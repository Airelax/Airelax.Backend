using System.Collections.Generic;
using Airelax.Application.WishLists.Dtos.Response;

namespace Airelax.Application.WishLists
{
    public interface IWishListService
    {
        void CreateWishList(string memberId, string wishName, string houseId);
        void DeleteWishList(int wishId);
        IEnumerable<WishListViewModel> GetWishList(string memberId);
        void UpdateWishList(string memberId, string houseId, int wishId);
    }
}