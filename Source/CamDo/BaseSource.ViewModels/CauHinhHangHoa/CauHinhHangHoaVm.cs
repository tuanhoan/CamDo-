using BaseSource.Shared.Enums;
using BaseSource.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ViewModels.CauHinhHangHoa
{
    public class GetCauHinhHangHoaPagingRequest : PageQuery
    {
        public string Ten { get; set; }
        public int LinhVuc { get; set; }
        public int? Status { get; set; }
    }
    public class CauHinhHangHoaVm
    {
        public int Id { get; set; }
        public ELinhVucHangHoa LinhVuc { get; set; }
        public string MaTS { get; set; }
        public string Ten { get; set; }
        public bool IsPublish { get; set; }
        public EHinhThucLai HinhThucLai { get; set; }
        public bool IsThuLaiTruoc { get; set; }
        public long SoTienCam { get; set; }
        public int Lai { get; set; }
        public int KyLai { get; set; }
        public int SoNgayVay { get; set; }
        public int SoNgayQuaHan { get; set; }
        public int? CuaHangId { get; set; }
        public string ListThuocTinh { get; set; }
    }
    public class CreateCauHinhHangHoaVm
    {
        [Display(Name = "Lĩnh vực")]
        [Required(ErrorMessage = "Vui lòng nhập lĩnh vực")]
        public ELinhVucHangHoa LinhVuc { get; set; }
        [Display(Name = "Mã hàng hóa")]
        [Required(ErrorMessage = "Vui lòng nhập mã hàng hóa")]
        public string MaTS { get; set; }
        [Display(Name = "Tên hàng hóa")]
        [Required(ErrorMessage = "Vui lòng nhập tên hàng hóa")]
        public string Ten { get; set; }
        [Display(Name = "Hoạt động")]
        public bool IsPublish { get; set; }
        [Display(Name = "Hình thức lãi")]
        [Required(ErrorMessage = "Vui lòng chọn hình thức lãi")]
        public EHinhThucLai HinhThucLai { get; set; }
        [Display(Name = "Thu lãi trước")]
        public bool IsThuLaiTruoc { get; set; }
        [Display(Name = "Số tiền cầm")]
        [Required(ErrorMessage = "Vui lòng nhập số tiền cầm")]
        public long SoTienCam { get; set; }
        [Display(Name = "Lãi")]

        public int Lai { get; set; }
        [Display(Name = "Kỳ lãi")]
        [Required(ErrorMessage = "Vui lòng nhập kỳ lãi")]
        public int KyLai { get; set; }
        [Display(Name = "Số ngày vay")]
        [Required(ErrorMessage = "Vui lòng nhập số ngày vay")]
        public int SoNgayVay { get; set; }
        [Display(Name = "Thanh lý sau")]
        [Required(ErrorMessage = "Vui lòng nhập số ngày quá hạn")]
        public int SoNgayQuaHan { get; set; }
        public int? CuaHangId { get; set; }
        [Display(Name = "Thuộc tính hàng hóa")]
        public string ListThuocTinh { get; set; }

    }
    public class EditCauHinhHangHoaVm : CreateCauHinhHangHoaVm
    {
        public int Id { get; set; }
    }
}
