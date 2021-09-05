using System;
using System.Collections.Generic;
using Airelax.Domain.DomainObject;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Airelax.Domain.Messages
{
    public class Message : AggregateRoot<string>
    {
        public string MemberOneId { get; set; }
        public string MemberTwoId { get; set; }
        public List<MessageContent> Contents { get; set; }
    }

    public class MessageContent
    {
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public string Content { get; set; }
        public DateTime Time { get; set; }
    }
}