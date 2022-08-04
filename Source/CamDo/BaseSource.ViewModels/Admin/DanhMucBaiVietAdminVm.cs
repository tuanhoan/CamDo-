using BaseSource.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ViewModels.Admin
{
    public class GetDanhMucBaiVietPagingRequest_Admin : PageQuery
    {
    }

    public class DanhMucBaiVietAdminVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Boolean DisableDelete { get; set; }
        public DateTime CreatedTime { get; set; }
    }

    public class CreateDanhMucBaiVietAdminVm
    {
        public string Name { get; set; }
    }

    public class EditDanhMucBaiVietAdminVm : CreateDanhMucBaiVietAdminVm
    {
        public int Id { get; set; }
    }
}
