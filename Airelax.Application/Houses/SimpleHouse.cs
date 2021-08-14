﻿using System.Collections.Generic;
using Airelax.Domain.Houses;
using Airelax.Domain.Houses.Defines;
using Airelax.Domain.Houses.Price;
using Airelax.Domain.Members;

namespace Airelax.Application.Houses
{
    public class SimpleHouse
    {
        public string Id { get; set; }
        public IEnumerable<byte[]> Picture { get; set; }
        public ICollection<WishList> WishList { get; set; }
        public HouseLocation Location { get; set; }
        public HousePrice Price { get; set; }
        public string Title { get; set; }
        public HouseCategory Category { get; set; }
        public IEnumerable<Facility> Facilities { get; set; }
        public int CustomerNumber { get; set; }
        public IEnumerable<Space> Space { get; set; }
        public SimpleComment Comment { get; set; }
    }
}