using System.Collections.Generic;

namespace Airelax.Application.WishLists.Dtos.Response
{
    public class WishListViewModel
    {
        public string Name { get; set; }
        public string Cover { get; set; }
        public List<string> Houses { get; set; }
    }
}
