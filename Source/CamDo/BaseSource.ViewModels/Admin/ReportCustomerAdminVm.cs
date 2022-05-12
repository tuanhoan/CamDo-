using BaseSource.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ViewModels.Admin
{
    public class GetReportCustomerPagingRequest_Admin : PageQuery
    {
        public string Info { get; set; }
    }

    public class ReportCustomerAdminVm
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string CMND { get; set; }
        public string Address { get; set; }
        public string Reason { get; set; }
        public string UserReport { get; set; }
        public string TenCuaHang { get; set; }
        public DateTime CreatedTime { get; set; }
    }
    public class EditReportCustomerAdminVm
    {
        public int Id { get; set; }
        [Display(Name = "Tên khách hàng")]
        [Required(ErrorMessage = "Vui lòng nhập tên khách hàng")]
        public string CustomerName { get; set; }
        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        public string PhoneNumber { get; set; }
        public string CMND { get; set; }
        public string Address { get; set; }
        [Display(Name = "Lý do")]
        [Required(ErrorMessage = "Vui lòng nhập lý do")]
        public string Reason { get; set; }
    }
}
