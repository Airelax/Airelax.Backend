using Airelax.Domain.DomainObject;

namespace Airelax.Domain.Comments
{
    public class Star:Entity<int>
    {
        public int CleanScore { get; set; }
        public int CommunicationScore { get; set; }
        public int ExperienceScore { get; set; }
        public int CheapScore { get; set; }
        public int LocationScore { get; set; }
        public int AccuracyScore { get; set; }
    }
}