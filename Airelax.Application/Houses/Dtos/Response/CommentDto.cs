using System;

namespace Airelax.Application.Houses.Dtos.Response
{
    public class CommentDto
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
    }
}