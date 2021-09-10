﻿using System.Collections.Generic;
using System.Linq;
using System.Net;
using Airelax.Application.Account;
using Airelax.Application.WishLists.Dtos.Request;
using Airelax.Application.WishLists.Dtos.Response;
using Airelax.Domain.Houses;
using Airelax.Domain.Members;
using Airelax.Domain.RepositoryInterface;
using Lazcat.Infrastructure.DependencyInjection;
using Lazcat.Infrastructure.ExceptionHandlers;
using Microsoft.AspNetCore.Authorization;

namespace Airelax.Application.WishLists
{
    [DependencyInjection(typeof(IWishListService))]
    [Authorize]
    public class WishListService : IWishListService
    {
        private readonly IHouseRepository _houseRepository;
        private readonly IMemberRepository _memberRepository;
        private readonly IAccountService _accountService;

        public WishListService(IHouseRepository houseRepository, IMemberRepository memberRepository, IAccountService accountService)
        {
            _houseRepository = houseRepository;
            _memberRepository = memberRepository;
            _accountService = accountService;
        }

        public void CreateWishList(CreateWishListInput input)
        {
            var member = _accountService.GetMember().Result;
            CheckMember(member, member.Id);
            CheckWishListName(member, input.WishName);
            var house = _houseRepository.GetAsync(x => x.Id == input.HouseId).Result;
            CheckHouse(house);

            var wishList = new WishList(member.Id)
            {
                Name = input.WishName,
                Houses = new List<string> { house.Id },
                Cover = house.Photos?.Select(x => x.Image).FirstOrDefault()
            };
            member.WishLists.Add(wishList);

            _memberRepository.UpdateAsync(member).Wait();
            _memberRepository.SaveChangesAsync().Wait();
        }

        public void UpdateWishName(UpdateWishListInput input)
        {
            var member = _accountService.GetMember().Result;
            CheckMember(member, member.Id);
            var house = _houseRepository.GetAsync(x => x.Id == input.HouseId).Result;
            CheckHouse(house);
            var wishList = member.WishLists.FirstOrDefault(x => x.Id == input.WishId);
            CheckWishListId(wishList);
            wishList.Name = input.WishName;

            _memberRepository.UpdateAsync(member).Wait();
            _memberRepository.SaveChangesAsync().Wait();
        }

        public void AddHouse(UpdateWishListInput input) //點擊房源Id清單api(愛心之後)
        {
            ReviseHouse(input, true);
        }

        public void RemoveHouse(UpdateWishListInput input) //點擊滿愛心(滿->空)
        {
            ReviseHouse(input, false);
        }

        private void ReviseHouse(UpdateWishListInput input, bool isadd)
        {
            var member = _accountService.GetMember().Result;
            CheckMember(member, member.Id);
            var house = _houseRepository.GetAsync(x => x.Id == input.HouseId).Result;
            CheckHouse(house);
            var wishList = member.WishLists.FirstOrDefault(x => x.Id == input.WishId);
            CheckWishListId(wishList);
            if (isadd == true)
                wishList.Houses.Add(house.Id);
            else
                wishList.Houses.Remove(house.Id);

            _memberRepository.UpdateAsync(member).Wait();
            _memberRepository.SaveChangesAsync().Wait();
        }

        public void DeleteWishList(int wishId)
        {
            var member = _accountService.GetMember().Result;
            CheckMember(member, member.Id);
            var wishList = member.WishLists.FirstOrDefault(x => x.Id == wishId);
            CheckWishListId(wishList);
            member.WishLists.Remove(wishList);

            _memberRepository.UpdateAsync(member).Wait();
            _memberRepository.SaveChangesAsync().Wait();
        }

        public IEnumerable<WishListViewModel> GetWishLists()
        {
            var member = _accountService.GetMember().Result;
            CheckMember(member, member.Id);

            var wishListsViewModel = member.WishLists.Select(m => new WishListViewModel
            {
                Id = m.Id,
                Name = m.Name,
                Cover = m.Cover,
                Houses = m.Houses
            });

            return wishListsViewModel;
        }

        public WishListViewModel GetHousesByWishList(int wishId)
        {
            var member = _accountService.GetMember().Result;
            CheckMember(member, member.Id);

            var wishList = member.WishLists.FirstOrDefault(m => m.Id == wishId);
            CheckWishListId(wishList);

            var wishListsViewModel = new WishListViewModel
            {
                Id = wishList.Id,
                Name = wishList.Name,
                Cover = wishList.Cover,
                Houses = wishList.Houses
            };

            //private static SimpleFacilityDto ConvertToSimpleFacilityDto(IEnumerable<Facility> facilities)
            //{
            //    var facilitiesList = facilities?.ToList();
            //    if (facilitiesList.IsNullOrEmpty()) return new SimpleFacilityDto();
            //    return new SimpleFacilityDto
            //    {
            //        AirConditioner = facilitiesList.Any(f => f == Facility.AirConditioner),
            //        Kitchen = facilitiesList.Any(f => f == Facility.Kitchen),
            //        WashingMachine = facilitiesList.Any(f => f == Facility.WashMachine),
            //        Wifi = facilitiesList.Any(f => f == Facility.Wifi)
            //    };
            //}


            return wishListsViewModel;
        }

        //Check區塊
        #region
        private void CheckMember(Member member, string memberId)
        {
            if (member == null) //判斷沒有會員
                throw ExceptionBuilder.Build(HttpStatusCode.BadRequest, $"memberId: {memberId} doesnt match member ");
        }

        private static void CheckWishListName(Member member, string wishListName)
        {
            if (member.WishLists.Any(w => w.Name == wishListName)) //有會員的情況,心願單-每個指定會員-找每個名字==帶入名字時
                throw ExceptionBuilder.Build(HttpStatusCode.BadRequest, "WishLists.Name cannot be repeated ");
        }

        private static void CheckHouse(House house)
        {
            if (house == null) //判斷沒有房源
                throw ExceptionBuilder.Build(HttpStatusCode.BadRequest, "doesnt match HouseId ");
        }

        private static void CheckWishListId(WishList wishList)
        {
            if (wishList == null)
                throw ExceptionBuilder.Build(HttpStatusCode.BadRequest, "doesnt match WishListId ");
        }
        #endregion
    }
}