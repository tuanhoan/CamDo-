using BaseSource.Shared.Enums;
using BaseSource.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace BaseSource.ViewModels.HopDong
{
    public class GetHopDongPagingRequest : PageQuery
    {
        public string Info { get; set; }
        public ELoaiHopDong LoaiHopDong { get; set; }
        public DateTime? FormDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? Status { get; set; }
        public int? LoaiHangHoa { get; set; }
    }
    public class HopDongVm
    {
        public int Id { get; set; }
        public int KhachHangId { get; set; }
        public int HangHoaId { get; set; }
        public string TenTaiSan { get; set; }
        public ELoaiHopDong HD_Loai { get; set; }
        public string HD_Ma { get; set; }
        public double HD_TongTienVayBanDau { get; set; }
        public EHinhThucLai? HD_HinhThucLai { get; set; }
        public bool HD_IsThuLaiTruoc { get; set; }
        public int HD_TongThoiGianVay { get; set; }
        public int HD_KyLai { get; set; }
        public double HD_LaiSuat { get; set; }
        public DateTime HD_NgayVay { get; set; }
        public DateTime HD_NgayDaoHan { get; set; }
        public DateTime? NgayDongLaiGanNhat { get; set; }
        public DateTime? NgayDongLaiTiepTheo { get; set; }
        public string HD_GhiChu { get; set; }
        public string ListThuocTinhHangHoa { get; set; }
        public string ImageList { get; set; }
        public double TongTienLai { get; set; }
        public double TongTienLaiDaThanhToan { get; set; }
        public double TongTienVayHienTai { get; set; }
        public double TongTienGhiNo { get; set; }
        public double TongTienThanhLy { get; set; }
        public double TongTienDaThanhToan { get; set; }
        public string UserIdAssigned { get; set; }
        public EThoiGianVay ThoiGian { get; set; }

        public string MaTaiSan { get; set; }
        public string TyLeLai { get; set; }
        public int TongSoNgayVay { get; set; }
        public double TienNo { get; set; }

        public string TenKhachHang { get; set; }
        public string CMND { get; set; }
        public DateTime? CMND_NgayCap { get; set; }
        public string CMND_NoiCap { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        //nợ khách hàng
        public bool IsDebit { get; set; }
        public string StatusName { get; set; }
        public byte HD_Status { get; set; }

    }
    public class CreateHopDongVm : IValidatableObject
    {
        public ELoaiHopDong LoaiHopDong { get; set; } = ELoaiHopDong.Camdo;

        [Display(Name = "Mã hợp đồng")]
        [Required(ErrorMessage = "Vui lòng nhập mã hợp đồng")]
        public string HD_Ma { get; set; }
        [Display(Name = "Loại tài sản")]
        public int HangHoaId { get; set; }
        [Display(Name = "Tên tài sản")]
        [Required(ErrorMessage = "Vui lòng nhập tên tài sản")]
        public string TenTaiSan { get; set; }
        [Display(Name = "Tổng số tiền vay")]
        [Required(ErrorMessage = "Vui lòng nhập tổng số tiền vay")]
        public double HD_TongTienVayBanDau { get; set; }
        [Display(Name = "Hình thức lãi")]
        public EHinhThucLai? HD_HinhThucLai { get; set; }
        [Display(Name = "Thu lãi trước")]
        public bool HD_IsThuLaiTruoc { get; set; }
        [Display(Name = "Số ngày vay")]
        [Required(ErrorMessage = "Vui lòng nhập số ngày vay")]
        public int HD_TongThoiGianVay { get; set; }
        [Display(Name = "Kỳ lãi")]
        [Required(ErrorMessage = "Vui lòng nhập kỳ lãi")]
        public int HD_KyLai { get; set; }
        [Display(Name = "Lãi")]
        [Required(ErrorMessage = "Vui lòng nhập tiền lãi")]
        public double HD_LaiSuat { get; set; }
        [Display(Name = "Ngày vay")]
        public DateTime HD_NgayVay { get; set; }
        [Display(Name = "Ghi chú")]
        public string HD_GhiChu { get; set; }
        [Display(Name = "NV thu tiền")]
        [Required(ErrorMessage = "Vui lòng chọn nhân viên")]
        public string UserIdAssigned { get; set; }
        public int KhachHangId { get; set; }
        [Display(Name = "Tên khách hàng")]
        [Required(ErrorMessage = "Vui lòng nhập tên khách hàng")]
        public string TenKhachHang { get; set; }
        [Display(Name = "Số CMND/Hộ chiếu")]
        public string CMND { get; set; }
        [Display(Name = "Số điện thoại")]
        public string SDT { get; set; }
        [Display(Name = "Ngày cấp")]
        public DateTime? CMND_NgayCap { get; set; }
        [Display(Name = "Nơi cấp")]
        public string CMND_NoiCap { get; set; }
        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }

        public string ListThuocTinhHangHoa { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (HD_TongTienVayBanDau < 0)
            {
                yield return new ValidationResult(
                    errorMessage: "Tổng tiền vay phải lớn hơn 0",
                    memberNames: new[] { "HD_TongTienVayBanDau" }
               );
            }
            if (HD_TongThoiGianVay == 0)
            {
                yield return new ValidationResult(
                    errorMessage: "Tổng thời gian vay phải lớn hơn 0",
                    memberNames: new[] { "HD_TongThoiGianVay" }
               );
            }
        }
    }

    public class CreateHopDongGopVonVm : IValidatableObject
    {
        public ELoaiHopDong LoaiHopDong { get; set; } = ELoaiHopDong.GopVon;

        [Display(Name = "Mã hợp đồng")]
        public string HD_Ma { get; set; }
        [Display(Name = "Loại tài sản")]
        public int HangHoaId { get; set; }
        [Display(Name = "Tên tài sản")]
        //[Required(ErrorMessage = "Vui lòng nhập tên tài sản")]
        public string TenTaiSan { get; set; }
        [Display(Name = "Số tiền đầu tư")]
        [Required(ErrorMessage = "Vui lòng nhập số tiền đâu tư")]
        public double HD_TongTienVayBanDau { get; set; }
        [Display(Name = "Hình thức lãi")]
        public EHinhThucLai? HD_HinhThucLai { get; set; }
        [Display(Name = "Thu lãi trước")]
        public bool HD_IsThuLaiTruoc { get; set; }
        [Display(Name = "Số ngày vay")]
        //[Required(ErrorMessage = "Vui lòng nhập số ngày vay")]
        public int HD_TongThoiGianVay { get; set; }
        [Display(Name = "Kỳ lãi")]
        //[Required(ErrorMessage = "Vui lòng nhập kỳ lãi")]
        public int HD_KyLai { get; set; }
        [Display(Name = "Lãi")]
        //[Required(ErrorMessage = "Vui lòng nhập tiền lãi")]
        public double HD_LaiSuat { get; set; }
        [Display(Name = "Ngày góp")]
        public DateTime HD_NgayVay { get; set; }
        [Display(Name = "Ghi chú")]
        public string HD_GhiChu { get; set; }
        [Display(Name = "NV thu tiền")]
        //[Required(ErrorMessage = "Vui lòng chọn nhân viên")]
        public string UserIdAssigned { get; set; }
        public int KhachHangId { get; set; }
        [Display(Name = "Tên khách hàng")]
        [Required(ErrorMessage = "Vui lòng nhập tên khách hàng")]
        public string TenKhachHang { get; set; }
        [Display(Name = "Số CMND/Hộ chiếu")]
        public string CMND { get; set; }
        [Display(Name = "Số điện thoại")]
        public string SDT { get; set; }
        [Display(Name = "Ngày cấp")]
        public DateTime? CMND_NgayCap { get; set; }
        [Display(Name = "Nơi cấp")]
        public string CMND_NoiCap { get; set; }
        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }

        public string ListThuocTinhHangHoa { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (HD_TongTienVayBanDau < 0 && HD_HinhThucLai != null && HD_HinhThucLai != 0)
            {
                yield return new ValidationResult(
                    errorMessage: "Tổng tiền vay phải lớn hơn 0",
                    memberNames: new[] { "HD_TongTienVayBanDau" }
               );
            }
            if (HD_TongThoiGianVay == 0 && HD_HinhThucLai != null && HD_HinhThucLai != 0)
            {
                yield return new ValidationResult(
                    errorMessage: "Tổng thời gian vay phải lớn hơn 0",
                    memberNames: new[] { "HD_TongThoiGianVay" }
               );
            }
        }
    }
    public class EditHopDongGopVonVm : CreateHopDongGopVonVm
    {
        public int Id { get; set; }
    }
    public class EditHopDongVm : CreateHopDongVm
    {
        public int Id { get; set; }
    }

    public class HopDongPaymentResponseVm
    {
        public DateTime NgayDongLaiGanNhat { get; set; }
        public double TongTienDaThanhToan { get; set; }
        public DateTime NgayDongLaiTiepTheo { get; set; }
    }

    public class HopDongNoLaiVm
    {
        [Required]
        public int HopDongId { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập số tiền")]
        [Range(100, int.MaxValue, ErrorMessage = "Số tiền phải lơn hơn 100 VNĐ")]
        public double? SoTienNoLai { get; set; }
    }
    public class HopDongTraNoVm
    {
        [Required]
        public int HopDongId { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập số tiền")]
        [Range(100, int.MaxValue, ErrorMessage = "Số tiền phải lơn hơn 100 VNĐ")]
        public double? SoTienTraNo { get; set; }
    }

    public class HopDong_AddChungTuVm
    {
        public int HopDongId { get; set; }
        public List<IFormFile> ListImage { get; set; }

        public EHopDong_ChungTuType ChungTuType { get; set; }
    }
    public class HopDong_ChungTuResponseVm
    {
        public int HopDongId { get; set; }
        public string ImageHopDong { get; set; }
        public string ImageKhachHang { get; set; }

    }
    public class DeleteChungTu_Vm
    {
        public int HopDongId { get; set; }
        public string Src { get; set; }
        public EHopDong_ChungTuType ChungTuType { get; set; }
    }
}
