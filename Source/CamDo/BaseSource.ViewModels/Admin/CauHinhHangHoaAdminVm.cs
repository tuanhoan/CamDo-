using BaseSource.Shared.Enums;
using BaseSource.ViewModels.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BaseSource.ViewModels.Admin
{
    public class GetCauHinhHangHoaPagingRequest_Admin : PageQuery
    {
        public string Ten { get; set; }
        public int LinhVuc { get; set; }
        public int? Status { get; set; }
    }
    public class CauHinhHangHoaAdminVm
    {
        public int Id { get; set; }
        public ELinhVucHangHoa LinhVuc { get; set; }
        public string MaTS { get; set; }
        public string Ten { get; set; }
        public bool IsPublish { get; set; }
        public EHinhThucLai HinhThucLai { get; set; }
        public bool IsThuLaiTruoc { get; set; }
        public double? TongTien { get; set; }
        public double LaiSuat { get; set; }
        public int KyLai { get; set; }
        public int TongThoiGianVay { get; set; }
        public int SoNgayQuaHan { get; set; }
        public int? CuaHangId { get; set; }
        public string ListThuocTinh { get; set; }
    }
    public class CreateCauHinhHangHoaAdminVm
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
        public bool IsThuLaiTruoc { get; set; }
        [Display(Name = "Tổng tiền")]
        [Required(ErrorMessage = "Vui lòng nhập tổng tiền")]
        public double? TongTien { get; set; }
        [Display(Name = "Lãi")]

        public double LaiSuat { get; set; }
        [Display(Name = "Kỳ lãi")]
        [Required(ErrorMessage = "Vui lòng nhập kỳ lãi")]
        public int KyLai { get; set; }
        [Display(Name = "Số ngày vay")]
        [Required(ErrorMessage = "Vui lòng nhập số ngày vay")]
        public int TongThoiGianVay { get; set; }
        [Display(Name = "Thanh lý sau")]
        [Required(ErrorMessage = "Vui lòng nhập số ngày quá hạn")]
        public int SoNgayQuaHan { get; set; }
        public int? CuaHangId { get; set; }
        [Display(Name = "Thuộc tính hàng hóa")]
        public string ListThuocTinh { get; set; }

    }
    public class EditCauHinhHangHoaAdminVm : CreateCauHinhHangHoaAdminVm
    {
        public int Id { get; set; }
        public List<ThuocTinhHangHoaVm_Admin> ThuocTinhs { get; set; }
    }
    public class ThuocTinhHangHoaVm_Admin
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
