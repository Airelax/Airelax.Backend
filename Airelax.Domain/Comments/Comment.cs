﻿using System;
using Airelax.Domain.DomainObject;
using Airelax.Domain.Houses;
using Airelax.Domain.Members;
using Airelax.Domain.Orders;

namespace Airelax.Domain.Comments
{
    public class Comment:AggregateRoot<int>
    {
        public int AuthorId { get; set; }
        public int HouseId { get; set; }
        public int ReceiverId { get; set; }
        public int OrderId { get; set; }
        public string Content { get; set; }
        public DateTime CommentTime{ get; set; }
        public DateTime? LastModifyTime { get; set; }

        public House House { get; set; }
        public Member Author { get; set; }
        public Member Receiver { get; set; }
        public Order Order { get; set; }
        public Star Star { get; set; }
    }
}