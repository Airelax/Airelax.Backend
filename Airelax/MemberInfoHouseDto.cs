
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airelax
{
    public class MemberInfoHouseDto
    {
        public string HouseId { get; set; }
        public string Cover { get; set; }
        public string HouseType { get; set; }
        public string RoomType { get; set; }
        public string RoomTitle { get; set; }
        public int CommentCount { get; set; }
        public double? StarScore { get; set; }
    }
}
