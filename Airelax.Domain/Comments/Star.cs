﻿using Airelax.Domain.DomainObject;

namespace Airelax.Domain.Comments
{
    public class Star : Entity<string>
    {
        public int CleanScore { get; set; }
        public int CommunicationScore { get; set; }
        public int ExperienceScore { get; set; }
        public int CheapScore { get; set; }
        public int LocationScore { get; set; }
        public int AccuracyScore { get; set; }

        public Star(string id, int cleanScore, int communicationScore, int experienceScore, int cheapScore, int locationScore, int accuracyScore)
        {
            Id = id;
            CleanScore = cleanScore;
            CommunicationScore = communicationScore;
            ExperienceScore = experienceScore;
            CheapScore = cheapScore;
            LocationScore = locationScore;
            AccuracyScore = accuracyScore;
        }
    }
}