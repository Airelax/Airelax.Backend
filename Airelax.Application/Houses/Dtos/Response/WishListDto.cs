using System.Collections.Generic;

namespace Airelax.Application.Houses.Dtos.Response
{
    public class WishListDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Cover { get; set; }
        public List<string> Houses { get; set; }
    }
}