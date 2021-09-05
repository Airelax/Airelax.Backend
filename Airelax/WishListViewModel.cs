using Airelax.Domain.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airelax
{
    public class WishListViewModel
    {
        public string Name { get; set; }
        public string Cover { get; set; }
        public List<string> Houses { get; set; }
    }
}
