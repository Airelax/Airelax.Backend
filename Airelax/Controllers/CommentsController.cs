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

            if (comments == null || !comments.Any()) return View(new List<HouseCommentViewModel>()
            {
                new HouseCommentViewModel()
                {
                    HouseId = "001",
                    HouseName = "米奇不妙屋",
                    HouseState = 1,
                    Comments = new List<CommentViewModel>(){
                        new CommentViewModel(){CommentId="100",Content="嬌娃這是今天的裝備",AuthorName="土豆",Stars=5.0, CommentTime = new DateTime(2020,12,31)},
                        new CommentViewModel(){CommentId="101",Content="吱吱喳喳",AuthorName="勞贖",Stars=4.5, CommentTime = new DateTime(2020,12,31)},
                        new CommentViewModel(){CommentId="102",Content="法式雜菜煲聽起來不好吃",AuthorName="小林",Stars=3.5, CommentTime = new DateTime(2021,1,1)},
                        new CommentViewModel(){CommentId="103",Content="吃起來像垃圾",AuthorName="大米",Stars=2.5, CommentTime = new DateTime(2021,1,1)}
                    }.ToArray()
                },
                new HouseCommentViewModel()
                {
                    HouseId = "002",
                    HouseName = "傑哥宅邸",
                    HouseState = 2,
                    Comments = new List<CommentViewModel>(){
                        new CommentViewModel(){CommentId="200",Content="沒錢我們就只能回家",AuthorName="彬彬",Stars=2.5, CommentTime = new DateTime(2020,12,31)},
                        new CommentViewModel(){CommentId="201",Content="還滿大的,",AuthorName="阿偉",Stars=3.5, CommentTime = new DateTime(2020,12,31)},
                        new CommentViewModel(){CommentId="202",Content="還滿大的,而且看到的",AuthorName="阿偉",Stars=4.5, CommentTime = new DateTime(2021,1,1)},
                        new CommentViewModel(){CommentId="203",Content="還滿大的,而且看到的都可以隨便拿",AuthorName="阿偉",Stars=5.0, CommentTime = new DateTime(2021,1,1)},
                        new CommentViewModel(){CommentId="204",Content="回家ㄚ~",AuthorName="彬彬",Stars=2.5, CommentTime = new DateTime(2021,1,1)}
                    }.ToArray()
                }
            });
            var commentViewModels = comments.Select(com => new HouseCommentViewModel()
            {
                HouseId = com.Key,
                HouseName = com.First().HouseName,
                HouseState = (int)com.First().HouseStatus,
                Comments = com.Select(c => new CommentViewModel()
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
