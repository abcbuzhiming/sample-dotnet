namespace SampleElasticsearchNet.Models
{
    /// <summary>
    /// 招投标数据
    /// </summary>
    public class TenderBidData
    {
        public string ProjectId { get; set; }
        public string CreateTime { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}