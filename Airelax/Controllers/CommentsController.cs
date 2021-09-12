using Airelax.Application.Comments;
using Airelax.Application.Comments.Dtos.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Airelax.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class CommentsController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var commentViewModels = _commentService.GetHouseComments();

            if (commentViewModels == null)
                return RedirectToAction("Index", "Error");

            return View(commentViewModels);
        }

        [HttpPost]
        public bool Create([FromBody] CreateOrUpdateCommentInput input)
        {
            _commentService.CreateOrUpdateComment(input);
            return true;
        }
    }
}