namespace Airelax.Application.MemberInfos.Request
{
    /// <summary>
    ///     從前端進來後端的class
    /// </summary>
    public class UpdateMemberInfoInput
    {
        /// <summary>
        ///     前端來的關於我
        /// </summary>
        public string About { get; set; }

        /// <summary>
        ///     前端來的位置
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        ///     前端來的工作時間
        /// </summary>
        public string WorkTime { get; set; }
    }
}