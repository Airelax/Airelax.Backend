using System;

namespace Airelax.Application.Houses.Dtos.Response
{
    public class CommentDto
    {
        public string AuthorId { get; set; }
        public string Cover { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Content { get; set; }
    }
}