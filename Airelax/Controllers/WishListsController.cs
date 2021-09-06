using System.Collections.Generic;
using Airelax.Application.WishLists;
using Airelax.Application.WishLists.Dtos.Request;
using Airelax.Application.WishLists.Dtos.Response;
using Microsoft.AspNetCore.Mvc;

namespace Airelax.Controllers
{
    [Route("api/[controller]")]
    public class WishListsController : Controller
    {
        private readonly IWishListService _wishListService;

        public WishListsController(IWishListService wishListService)
        {
            _wishListService = wishListService;
        }

        [HttpPost]
        public bool Create( [FromBody] CreateWishListInput input)
        {
            _wishListService.CreateWishList(input);
            return true;
        }

        [HttpPut]
        public bool Update([FromBody] UpdateWishListInput input)
        {
            _wishListService.UpdateWishList(input);
            return true;
        }

        [HttpDelete]
        public bool Delete([FromBody] DeleteWishListInput input)
        {
            _wishListService.DeleteWishList(input.WishId);
            return true;
        }

        [HttpGet]
        public IEnumerable<WishListViewModel> Get(string memberId)
        {
            return _wishListService.GetWishList(memberId);
        }
    }
}