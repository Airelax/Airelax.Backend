using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airelax
{
    public class MemberInfoViewModel
    {
        public string About { get; set; }
        public string Location { get; set; }
        public string WorkTime { get; set; }
        public string MemberName { get; set; }
        public string MemberImg { get; set; }
        public string RegisterTime { get; set; }
        public string Email { get; set; }
        public IEnumerable<MemberInfoHouseDto> HouseSource { get; set; }

        //todo 楚原評價
    }
}
