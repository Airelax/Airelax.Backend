using Airelax.Domain.Houses;
using Airelax.Domain.Members;
using Airelax.EntityFramework.DbContexts;
using Lazcat.Infrastructure.ExceptionHandlers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airelax.Controllers
{
    public class WishListsController : Controller
    {
        private readonly IWishListService _wishListService;

        public WishListsController(IWishListService wishListService)
        {
            _wishListService = wishListService;
        }
        [HttpPost]
        [Route("{memberId}")]
        public bool Create(string memberId, [FromBody] CreateWishListInput input)
        {
            _wishListService.CreateWishList(memberId, input.WishName, input.HouseId);
            return true;
        }
        [HttpPut]
        [Route("{memberId}")]
        public bool Update(string memberId, [FromBody] UpdateWishListInput input)
        {
            _wishListService.UpdateWishList(memberId, input.HouseId, input.WishId);
            return true;
        }
        [HttpDelete]
        [Route("{memberId}")]
        public bool Delete([FromBody] DeleteWishListInput input)
        {
            _wishListService.DeleteWishList(input.WishId);
            return true;
        }
        [HttpGet]
        [Route("{memberId}")]
        public IEnumerable<WishListViewModel> Get(string memberId)
        {
            return _wishListService.GetWishList(memberId);
        }
    }
}
