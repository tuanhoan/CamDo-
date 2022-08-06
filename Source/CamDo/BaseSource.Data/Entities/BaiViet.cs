using System;

namespace BaseSource.Data.Entities
{
    public class BaiViet
    {
        public int Id { get; set; }
        public int DanhMucBaiVietId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string Url { get; set; }
        public DateTime CreatedTime { get; set; }
        public DanhMucBaiViet DanhMucBaiViet { get; set; }
    }
}
