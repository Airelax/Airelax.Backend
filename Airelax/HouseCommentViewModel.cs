using Airelax.Domain.Comments;
using Airelax.Domain.DomainObject;
using Lazcat.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airelax
{
    public class HouseCommentViewModel
    {
        public string HouseId { get; set; }
        public string HouseName { get; set; }
        public int HouseState { get; set; }
        public CommentViewModel[] Comments { get; set; }
    }
    public class CommentViewModel
    {
        public string CommentId { get; set; }
        public DateTime CommentTime { get; set; }
        public string AuthorName { get; set; }
        public string Content { get; set; }
        public double Stars { get; set; }
    }
}