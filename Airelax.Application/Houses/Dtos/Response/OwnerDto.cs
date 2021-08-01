﻿using System;

namespace Airelax.Application.Houses.Dtos.Response
{
    public class OwnerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime RegisterTime { get; set; }
        public int TotalComments { get; set; }
        public bool IsVerified { get; set; }
        public string About { get; set; }
    }
}