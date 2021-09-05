using Airelax.Domain.Houses;
using Airelax.Domain.Members;
using Lazcat.Infrastructure.DependencyInjection;
using Lazcat.Infrastructure.ExceptionHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airelax
{
    [DependencyInjection(typeof(IWishListService))]
    public class WishListService : IWishListService
    {
        private readonly IWishListRepository _wishListRepository;

        public WishListService(IWishListRepository wishListRepository)
        {
            _wishListRepository = wishListRepository;
        }
        private void CheckMember(Member member, string memberId)
        {
            if (member == null) //判斷沒有會員
                throw ExceptionBuilder.Build(System.Net.HttpStatusCode.BadRequest, $"memberId: {memberId} doesnt match member ");
        }
        private void CheckWishListName(Member member, string wishListName)
        {
            if (member.WishLists.Any(w => w.Name == wishListName)) //有會員的情況,心願單-每個指定會員-找每個名字==帶入名字時
                throw ExceptionBuilder.Build(System.Net.HttpStatusCode.BadRequest, $"WishLists.Name cannot be repeated ");
            //if (member.WishLists.SelectMany(m => m.Houses).Any(m => m == input.HouseId)) //有會員的情況,心願單-每個指定會員-找每個房源Id==帶入Id時
            //    throw ExceptionBuilder.Build(System.Net.HttpStatusCode.BadRequest, $"memberId: {memberId} doesnt match member ");
        }
        private void CheckHouse(House house)
        {
            if (house == null) //判斷沒有房源
                throw ExceptionBuilder.Build(System.Net.HttpStatusCode.BadRequest, $"doesnt match HouseId ");
        }
        private void CheckWishListId(WishList wishList)
        {
            if (wishList == null)
                throw ExceptionBuilder.Build(System.Net.HttpStatusCode.BadRequest, $"doesnt match WishListId ");
        }
        public void CreateWishList(string memberId, string WishName, string HouseId)
        {
            var member = _wishListRepository.GetMember(memberId);
            CheckMember(member, memberId);
            CheckWishListName(member, WishName);
            var wishListHouse = _wishListRepository.GetHouses(HouseId);
            CheckHouse(wishListHouse);

            var wishList = (
            new WishList(member.Id)
            {
                Name = WishName,
                Houses = new List<string> { wishListHouse.Id },
                Cover = wishListHouse.Photos?.Select(x => x.Image).FirstOrDefault()
            });
            _wishListRepository.Add(wishList);
            _wishListRepository.SaveChanges();
        }
        public void UpdateWishList(string memberId, string HouseId, int WishId)
        {
            var member = _wishListRepository.GetMember(memberId);
            CheckMember(member, memberId);
            var wishListHouse = _wishListRepository.GetHouses(HouseId);
            CheckHouse(wishListHouse);
            var wishList = _wishListRepository.GetWishList(WishId);
            CheckWishListId(wishList);

            wishList.Houses.Add(HouseId);
            wishList.Houses = wishList.Houses.Distinct().ToList();
            _wishListRepository.SaveChanges();
        }
        public void DeleteWishList(int WishId)
        {
            var wishList = _wishListRepository.GetWishList(WishId);
            CheckWishListId(wishList);

            _wishListRepository.Remove(wishList);
            _wishListRepository.SaveChanges();
        }
        public IEnumerable<WishListViewModel> GetWishList(string memberId)
        {
            var member = _wishListRepository.GetMember(memberId);
            CheckMember(member, memberId);

            var wishListsViewModel = member.WishLists.Select(m => new WishListViewModel()
            {
                Name = m.Name,
                Cover = m.Cover,
                Houses = m.Houses
            });

            return wishListsViewModel;
        }
    }
}
