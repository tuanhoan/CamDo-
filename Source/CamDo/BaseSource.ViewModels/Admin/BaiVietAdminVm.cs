using BaseSource.ViewModels.Common;
using System;
using System.Collections.Generic;

namespace BaseSource.ViewModels.Admin
{
    public class GetBaiVietPagingRequest_Admin : PageQuery
    {
    }

    public class BaiVietAdminVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string Url { get; set; }
        public DateTime CreatedTime { get; set; }
        public DanhMucBaiVietAdminVm DanhMucBaiViet { get; set; }
    }

    public class CreateBaiVietAdminVm
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public string Url { get; set; }
        public int DanhMucBaiVietId { get; set; }

        public List<DanhMucBaiVietAdminVm> DanhMucSelect;
    }

    public class EditBaiVietAdminVm : CreateBaiVietAdminVm
    {
        public int Id { get; set; }
    }
}
