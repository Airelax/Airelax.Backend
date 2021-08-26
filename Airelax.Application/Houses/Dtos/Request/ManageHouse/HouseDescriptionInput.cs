using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airelax.Application.Houses.Dtos.Request.ManageHouse
{
    public class HouseDescriptionInput
    {
        public string Description { get; set; }
        public string SpaceDescription { get; set; }
        public string GuestPermission { get; set; }
        public string Others { get; set; }
    }
}
