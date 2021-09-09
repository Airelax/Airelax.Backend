using System.Collections.Generic;
using Airelax.Application.WishLists.Dtos.Request;
using Airelax.Application.WishLists.Dtos.Response;

namespace Airelax.Application.WishLists
{
    public interface IWishListService
    {
        void CreateWishList(CreateWishListInput input);
        void DeleteWishList(int wishId);
        IEnumerable<WishListViewModel> GetWishLists();
        void UpdateWishName(UpdateWishListInput input);
        void UpdateWishHouses(UpdateWishListInput input);
        WishListViewModel GetHousesByWishList(int wishId);
    }
}