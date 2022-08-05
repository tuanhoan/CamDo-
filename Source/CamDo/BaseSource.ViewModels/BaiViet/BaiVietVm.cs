using System;
using System.Collections.Generic;

namespace BaseSource.ViewModels.BaiViet
{
    public class BaiVietVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string Url { get; set; }
        public DateTime CreatedTime { get; set; }
    }

    public class TinhNangPageVm
    {
        public BaiVietVm baiViet { get; set; }
        public List<BaiVietVm> menus { get; set; }
    }
}
