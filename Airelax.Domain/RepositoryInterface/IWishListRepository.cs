using Airelax.Domain.Houses;
using Airelax.Domain.Members;

namespace Airelax.Domain.RepositoryInterface
{
    public interface IWishListRepository
    {
        void Add(WishList wishList);
        House GetHouses(string HouseId);
        Member GetMember(string memberId);
        WishList GetWishList(int WishId);
        void Remove(WishList wishList);
        void SaveChanges();
    }
}