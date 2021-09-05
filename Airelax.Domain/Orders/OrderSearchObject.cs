using Airelax.Domain.Comments;
using Airelax.Domain.Houses.Price;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airelax
{
    public class OrderSearchObject
    {
        public HousePrice HousePrice { get; set; }
        public ICollection<Comment> Comment { get; set; }
    }
}
