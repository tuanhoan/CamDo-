using BaseSource.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ViewModels.Admin
{
    public class GetGoiSanPhamPagingRequest_Admin : PageQuery
    {
        public string Info { get; set; }
    }
    public class GoiSanPhamAdminVm
    {
        public int Id { get; set; }
        public string Ten { get; set; }
        public int SoThang { get; set; }
        public double TongTien { get; set; }
        public string MoTa { get; set; }
        public string KhuyenMai { get; set; }
        public DateTime CreatedTime { get; set; }
    }
    public class CreateGoiSanPhamVm
    {
        [Display(Name = "Tên sản phẩm")]
        [Required(ErrorMessage = "Vui lòng nhập tên sản phẩm")]
        public string Ten { get; set; }
        [Display(Name = "Số tháng")]
        [Required(ErrorMessage = "Vui lòng nhập số tháng")]
        public int SoThang { get; set; }
        [Display(Name = "Tổng tiền")]
        [Required(ErrorMessage = "Vui lòng nhập tổng tiền")]
        public double TongTien { get; set; }
        [Display(Name = "Mô tả")]
        public string MoTa { get; set; }
        [Display(Name = "Khuyến mãi")]
        public string KhuyenMai { get; set; }
    }
    public class EditGoiSanPhamVm : CreateGoiSanPhamVm
    {
        public int Id { get; set; }
    }
}
