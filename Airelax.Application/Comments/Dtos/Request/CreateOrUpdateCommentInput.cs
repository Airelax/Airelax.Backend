namespace Airelax.Application.Comments.Dtos.Request
{
    public class CreateOrUpdateCommentInput
    {
        public string OrderId { get; set; }
        public string Content { get; set; }
        public int CleanScore { get; set; }
        public int CommunicationScore { get; set; }
        public int ExperienceScore { get; set; }
        public int CheapScore { get; set; }
        public int LocationScore { get; set; }
        public int AccuracyScore { get; set; }
    }
}