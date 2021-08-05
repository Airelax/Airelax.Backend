﻿using System;
using Airelax.Domain.DomainObject;
using Airelax.Domain.Houses;
using Airelax.Domain.Members;
using Airelax.Domain.Orders;

namespace Airelax.Domain.Comments
{
    public class Comment : AggregateRoot<int>
    {
        public int AuthorId { get; set; }
        public int HouseId { get; set; }
        public int ReceiverId { get; set; }
        public int OrderId { get; set; }
        public string Content { get; set; }
        public DateTime CommentTime { get; set; }
        public DateTime? LastModifyTime { get; set; }


        public Comment( int authorId, int houseId, int receiverId, int orderId, string content)
        {
       
            AuthorId = authorId;
            HouseId = houseId;
            ReceiverId = receiverId;
            OrderId = orderId;
            Content = content;
            CommentTime = DateTime.Now;
            LastModifyTime = DateTime.Now;
        }
    }
}