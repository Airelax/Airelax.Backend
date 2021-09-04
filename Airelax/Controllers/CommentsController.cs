using Airelax.Domain.Comments;
using Airelax.Domain.Orders;
using Airelax.EntityFramework.DbContexts;
using Lazcat.Infrastructure.ExceptionHandlers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Airelax.Controllers
{
    [Route("[controller]")]
    public class CommentsController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        [Route("{memberId}")]
        public IActionResult Index(string memberId)
        {
            var commentViewModels = _commentService.GetHouseComments(memberId);


            if (commentViewModels == null)
                //todo error page
                return View();

            return View(commentViewModels);
        }

        [HttpPost]
        public bool Create([FromBody] CreateCommentInput input)
        {
            _commentService.CreateComment(input);
            return true;
        }
    }
}
