using BaseSource.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ViewModels.Admin
{
    public class GetFeedBackPagingRequest_Admin : PageQuery
    {
        public string Info { get; set; }
    }
    public class FeedBackAdminVm
    {
        public int Id { get; set; }
        public string FeedBackContent { get; set; }
        public string UserFeedBack { get; set; }
        public string UserId { get; set; }
        public int CuaHangId { get; set; }
        public string TenCuaHang { get; set; }
        public DateTime CreatedTime { get; set; }
    }
   
}
