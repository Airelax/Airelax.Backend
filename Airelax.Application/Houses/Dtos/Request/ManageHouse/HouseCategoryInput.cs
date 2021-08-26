﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airelax.Domain.Houses.Defines;

namespace Airelax.Application.Houses.Dtos.Request.ManageHouse
{
    public class HouseCategoryInput
    {
        public Category Category { get; set; }
        public HouseType? HouseType { get; set; }
        public RoomCategory? RoomCategory { get; set; }
    }
}
