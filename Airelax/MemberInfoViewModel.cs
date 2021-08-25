using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airelax
{
    public class MemberInfoViewModel
    {
        public string MemberId { get; set; }
        /// <summary>
        /// 關於我
        /// </summary>
        public string About { get; set; }
        /// <summary>
        /// 位置
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// 工作時間
        /// </summary>
        public string WorkTime { get; set; }
        public string MemberName { get; set; }
        /// <summary>
        /// 會員相片
        /// </summary>
        public string MemberImg { get; set; }
        /// <summary>
        /// 加入時間
        /// </summary>
        public string RegisterTime { get; set; }
        /// <summary>
        /// 電子郵件
        /// </summary>
        public string Email { get; set; }
        public IEnumerable<MemberInfoHouseDto> HouseSource { get; set; }

        //todo 楚原評價
    }
}
