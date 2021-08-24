using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airelax.Domain.Houses.Defines;

namespace Airelax.Application.Houses.Dtos.Response
{
    public class HouseCategoryVM
    {
        public int? Category { get; set; }
        public int? HouseType { get; set; }
        public int? RoomCategory { get; set; }
    }
}
