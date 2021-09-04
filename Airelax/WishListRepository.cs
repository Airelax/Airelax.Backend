﻿using Airelax.Domain.Houses;
using Airelax.Domain.Members;
using Airelax.EntityFramework.DbContexts;
using Lazcat.Infrastructure.DependencyInjection;
using Lazcat.Infrastructure.ExceptionHandlers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airelax
{
    [DependencyInjection(typeof(IWishListRepository))]
    public class WishListRepository : IWishListRepository
    {
        private readonly AirelaxContext _context;
        public WishListRepository(AirelaxContext context)
        {
            _context = context;
        }
        public Member GetMember(string memberId)
        {
            return _context.Members.Include(m => m.WishLists)
                                   .FirstOrDefault(m => m.Id == memberId && !m.IsDeleted);
        }
        public House GetHouses(string HouseId)
        {
            return _context.Houses.Include(w => w.Photos)
                                  .FirstOrDefault(w => w.Id == HouseId);
        }
        public WishList GetWishList(int WishId)
        {
            return _context.WishLists.FirstOrDefault(x => x.Id == WishId);
        }
        public void Add(WishList wishList)
        {
            _context.WishLists.Add(wishList);
        }
        public void Remove(WishList wishList)
        {
            _context.WishLists.Remove(wishList);
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
