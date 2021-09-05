using Airelax.Application.Comments;
using Airelax.Application.Comments.Dtos.Request;
using Microsoft.AspNetCore.Mvc;

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