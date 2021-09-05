using Airelax.Domain.Comments;
using Airelax.Domain.Houses.Defines;

namespace Airelax
{
    public class HouseCommentObject
    {
        public Comment Comment { get; set; }
        public string HouseId { get; set; }
        public string HouseName { get; set; }
        public HouseStatus HouseStatus { get; set; }
        public string Members { get; set; }
        public Star Stars { get; set; }
    }
}