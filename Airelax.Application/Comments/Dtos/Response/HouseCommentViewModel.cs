namespace Airelax.Application.Comments.Dtos.Response
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
        public string CommentTime { get; set; }
        public string AuthorName { get; set; }
        public string Content { get; set; }
        public double Stars { get; set; }
    }
}