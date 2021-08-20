using Airelax.EntityFramework.DbContexts;
using Lazcat.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airelax.Controllers
{
    public class CommentsController : Controller
    {
        private readonly AirelaxContext _context;

        public CommentsController(AirelaxContext context)
        {
            _context = context;
        }
        public IActionResult Index(string memberId)
        {
            var comments =
                          from c in _context.Comments
                          join m in _context.Members on c.AuthorId equals m.Id
                          join h in _context.Houses on m.Id equals h.OwnerId
                          join s in _context.Stars on h.Id equals s.Id
                          where m.Id == memberId
                          group new { Comment = c, HouseId = h.Id, HouseName = h.Title, HouseStatus = h.Status, Members = m.Name, Stars = s } by h.Id into com
                          select com;

            if (comments == null || !comments.Any()) return View(new List<CommentViewModel>()
            {
                new CommentViewModel()
                {
                    HouseId = "001",
                    HouseName = "傑哥宅邸",
                    HouseState = 1,
                    Comments = new List<Comment>(){
                        new Comment(){CommentId="100",Content="沒錢我們就只能回家ㄚ~",AuthorName="彬彬",Stars=2.5,CommentTime=DateTime.Now},
                        new Comment(){CommentId="101",Content="還滿大的,而且看到的都可以隨便拿",AuthorName="阿偉",Stars=5.0, CommentTime = new DateTime(1998,12,31)},
                        new Comment(){CommentId="102",Content="還滿大的,而且看到的都可以隨便拿",AuthorName="阿偉",Stars=5.0},
                        new Comment(){CommentId="103",Content="還滿大的,而且看到的都可以隨便拿",AuthorName="阿偉",Stars=5.0}
                    }.ToArray()
                },
                new CommentViewModel()
                {
                    HouseId = "002",
                    HouseName = "傑哥宅邸",
                    HouseState = 2,
                    Comments = new List<Comment>(){
                        new Comment(){CommentId="200",Content="沒錢我們就只能回家ㄚ~",AuthorName="彬彬",Stars=2.5},
                        new Comment(){CommentId="201",Content="還滿大的,而且看到的都可以隨便拿",AuthorName="阿偉",Stars=5.0},
                        new Comment(){CommentId="202",Content="還滿大的,而且看到的都可以隨便拿",AuthorName="阿偉",Stars=5.0},
                        new Comment(){CommentId="203",Content="還滿大的,而且看到的都可以隨便拿",AuthorName="阿偉",Stars=5.0},
                        new Comment(){CommentId="204",Content="沒錢我們就只能回家ㄚ~",AuthorName="彬彬",Stars=2.5}
                    }.ToArray()
                }
            });
            var commentViewModels = comments.Select(com => new CommentViewModel()
            {
                HouseId = com.Key,
                HouseName = com.First().HouseName,
                HouseState = (int)com.First().HouseStatus,
                Comments = com.Select(c => new Comment()
                {
                    CommentId = c.Comment.Id,
                    CommentTime = c.Comment.CommentTime,
                    Content = c.Comment.Content,
                    AuthorName = c.Members,
                    Stars = c.Stars.Total
                }).ToArray()
            });
            //var commentViewModels = new List<CommentViewModel>();
            //var commentDto = comments.GroupBy(com=>com.HouseId).Select(com=>new Comment()

            //var commentViewModel = new CommentViewModel()
            //{
            //    AuthorId = com.AuthorName,
            //    HouseId = com.Comment.HouseId,
            //    Content = com.Comment.Content,
            //    CommentTime = com.Comment.CommentTime,
            //    HouseName = com.HouseName,
            //    HouseState = (int)com.HouseStatus,
            //    Stars = com.Stars.Total
            //};
            return View(commentViewModels);
        }
    }
}
