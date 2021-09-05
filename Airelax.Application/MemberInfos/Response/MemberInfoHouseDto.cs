namespace Airelax.Application.MemberInfos.Response
{
    /// <summary>
    ///     房源ViewModel
    /// </summary>
    public class MemberInfoHouseDto
    {
        public string HouseId { get; set; }

        /// <summary>
        ///     房屋相片封面
        /// </summary>
        public string Cover { get; set; }

        /// <summary>
        ///     屋型
        /// </summary>
        public string HouseType { get; set; }

        /// <summary>
        ///     房型
        /// </summary>
        public string RoomType { get; set; }

        /// <summary>
        ///     標題
        /// </summary>
        public string RoomTitle { get; set; }

        /// <summary>
        ///     評價數量
        /// </summary>
        public int CommentCount { get; set; }

        /// <summary>
        ///     星星分數
        /// </summary>
        public double? StarScore { get; set; }
    }
}