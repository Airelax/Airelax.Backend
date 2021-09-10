using Airelax.Domain.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airelax.Domain.Houses
{
    class Fwefmwl
    {
        //Houses
        public string Title { get; set; }
        public int CustomerNumber { get; set; }//顧客數
        
        //HouseCategory
        public HouseCategory HouseCategory { get; set; }
        //public int Category { get; set; }//公寓,獨棟房屋
        //public int HouseType { get; set; }//獨棟公寓,樹屋
        //public int RoomCategory { get; set; }//整個房源,獨立房間,合租房間

        //Spaces
        public int SpaceType { get; set; }

        //BedroomDetaill
        public int BedType { get; set; }
        public bool hasDependentBath { get; set; }

        //Price
        public decimal PricePerNight { get; set; }

        public Star Star { get; set; }
    }
}
