using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.Shared.Enums
{
    public enum EFeatureType : byte
    {
        [Display(Name = "Cầm đồ")]
        Camdo = 1,
        [Display(Name = "Vay lãi")]
        Vaylai = 2,
        [Display(Name = "Góp vốn")]
        GopVon = 3,
        [Display(Name = "Thu")]
        Thu = 4,
        [Display(Name = "Chi")]
        Chi = 5
    }

    public enum ELoaiHopDong : byte
    {
        [Display(Name = "Cầm đồ")]
        Camdo = EFeatureType.Camdo,
        [Display(Name = "Vay lãi")]
        Vaylai = EFeatureType.Vaylai,
        [Display(Name = "Góp vốn")]
        GopVon = EFeatureType.GopVon,
        [Display(Name = "Vay Họ")]
        VayHo = 4
    }

    public enum ELinhVucHangHoa : byte
    {
        [Display(Name = "Cầm đồ")]
        Camdo = EFeatureType.Camdo,
        [Display(Name = "Vay lãi")]
        Vaylai = EFeatureType.Vaylai
    }

    public enum EHinhThucLai : byte
    {
        [Display(Name = "Lãi ngày (k/triệu)")]
        LaiNgayKTrieu = 1,
        [Display(Name = "Lãi ngày (k/ngày)")]
        LaiNgayKNgay = 2,
        [Display(Name = "Lãi tháng(%)(30 ngày)")]
        LaiThangPhanTram = 3,
        [Display(Name = "Lãi tháng (định kì)")]
        LaiThangDinhKi = 4,
        [Display(Name = "Lãi tuần (%)")]
        LaiTuanPhanTram = 5,
        [Display(Name = "Lãi tuần (VNĐ)")]
        LaiTuanVND = 6,

    }

    public enum ECamDo_HopDongPrintTemplate : byte
    {
        [Display(Name = "Lãi suất")]
        LaiSuat = 0,
        [Display(Name = "Lãi thỏa thuận")]
        LaiThoaThuan
    }

    public enum EVayLai_HopDongPrintTemplate : byte
    {
        [Display(Name = "Lãi suất")]
        LaiSuat = 0,
        [Display(Name = "Lãi thỏa thuận")]
        LaiThoaThuan
    }

    public enum EHopDong_ActionType : byte
    {
        [Display(Name = "Tạo mới hợp đồng")]
        TaoMoiHD = 1,
        [Display(Name = "Update hợp đồng")]
        UpdateHD = 2,
        [Display(Name = "Đóng tiền lãi")]
        DongTienLai = 3,
        [Display(Name = "Hủy đóng tiền lãi")]
        HuyDongTienLai = 4,
        [Display(Name = "Trả gốc")]
        TraGoc = 5,
        [Display(Name = "Vay thêm gốc")]
        VayThemGoc = 6,
        [Display(Name = "Hủy trả gốc")]
        HuyTraGoc = 7,
        [Display(Name = "Hủy vay thêm gốc")]
        HuyVayThemGoc = 8,
        [Display(Name = "Đóng hợp đồng")]
        DongHD = 9,
        [Display(Name = "Nợ lãi")]
        NoLai = 10,
        [Display(Name = "Trả nợ")]
        TraNo = 11,
        [Display(Name = "Gia hạn")]
        GiaHan = 12,
        [Display(Name = "Mở lại hợp đồng")]
        MoLaiHD = 13,
        [Display(Name = "Thanh lý đồ")]
        ThanhLyDo = 14,
        [Display(Name = "Xóa hợp đồng")]
        XoaHD = 15,
        [Display(Name = "Chờ thanh lý")]
        ChoThanhLy = 16
    }

    public enum EPhieuThu_ActionType : byte
    {
        [Display(Name = "Thu khác")]
        ThuKhac = 1,
        [Display(Name = "Thu trả quỹ")]
        ThuTraQuy = 2,
        [Display(Name = "Thu tiền nợ")]
        ThuTienNo = 3,
        [Display(Name = "Thu tiền ứng")]
        ThuTienUng = 4,
        [Display(Name = "Thu tiền phạt")]
        ThuTienPhat = 5,
        [Display(Name = "Hoa hồng")]
        HoaHong = 6,
        [Display(Name = "Thu vé hoặc văn phòng")]
        ThuVeHoacVanPhong = 7,
        [Display(Name = "Hủy phiếu thu")]
        HuyPhieuThu = 8
    }

    public enum EPhieuChi_ActionType : byte
    {
        [Display(Name = "Chi khác")]
        ChiKhac = 1,
        [Display(Name = "Trả lương")]
        TraLuong = 2,
        [Display(Name = "Trả lãi")]
        TraLai = 3,
        [Display(Name = "Chi tiêu dùng")]
        ChiTieuDung = 4,
        [Display(Name = "Chi trả quỹ")]
        ChiTraQuy = 5,
        [Display(Name = "Tạm ứng")]
        TamUng = 6,
        [Display(Name = "Hoa hồng")]
        HoaHong = 7,
        [Display(Name = "Chi vé hoặc văn phòng")]
        ChiVeHoacVanPhong = 8,
        [Display(Name = "Hủy phiếu chi")]
        HuyPhieuChi = 9
    }

    public enum EQuyTienCuaHang_LogType : byte
    {
        [Display(Name = "Tiền đầu ngày")]
        TienDauNgay = 1,
        [Display(Name = "Quỹ tiền mặt")]
        QuyTienMat = 2
    }

    public enum ETienDauNgay_ActionType : byte
    {
        [Display(Name = "Cập nhật tiền đầu ngày")]
        CapNhat = 1,
        [Display(Name = "Thêm tiền đầu ngày")]
        ThemTien = 2,
        [Display(Name = "Rút tiền đầu ngày")]
        RutTien = 3,
    }

    public enum EQuyTienMat_ActionType : byte
    {
        [Display(Name = "Nhập lại quỹ tiền mặt")]
        NhapLaiQuy = 1
    }

    public enum EThoiGianVay : byte
    {
        [Display(Name = "Ngày")]
        Ngay = 1,
        [Display(Name = "Tuần")]
        Tuan,
        [Display(Name = "Tháng")]
        Thang
    }

    #region not in database
    public enum EHopDong_CommonStatusFilter : byte
    {
        [Display(Name = "Đúng hẹn")]
        DungHen = 1,
        [Display(Name = "Quá hạn")]
        QuaHan = 2,
        [Display(Name = "Chậm lãi")]
        ChamLai = 3,
        [Display(Name = "Đã thanh lý")]
        DaThanhLy = 4,
        [Display(Name = "Kết thúc/Đã chuộc")]
        KetThuc = 5,
        [Display(Name = "Đã xóa")]
        DaXoa = 6,
        [Display(Name = "Chờ thanh lý/Nợ xấu")]
        ChoThanhLy = 7
    }

    public enum EHopDong_CamDoStatusFilter : byte
    {
        [Display(Name = "Quá hạn")]
        QuaHan = EHopDong_CommonStatusFilter.QuaHan,
        [Display(Name = "Chậm lãi")]
        ChamLai = EHopDong_CommonStatusFilter.ChamLai,
        [Display(Name = "Đã thanh lý")]
        DaThanhLy = EHopDong_CommonStatusFilter.DaThanhLy,
        [Display(Name = "Đã chuộc")]
        KetThuc = EHopDong_CommonStatusFilter.KetThuc,
        [Display(Name = "Đã xóa")]
        DaXoa = EHopDong_CommonStatusFilter.DaXoa,
        [Display(Name = "Chờ thanh lý")]
        ChoThanhLy = EHopDong_CommonStatusFilter.ChoThanhLy,
        [Display(Name = "Đang cầm")]
        DangCam,
        [Display(Name = "Đến ngày chuộc đồ")]
        DenNgayChuocDo,
        [Display(Name = "Hôm nay đóng tiền")]
        HomNayDongTien,
     
    }

    public enum EHopDong_VayLaiStatusFilter : byte
    {
        [Display(Name = "Đúng hẹn")]
        DungHen = EHopDong_CommonStatusFilter.DungHen,
        [Display(Name = "Quá hạn")]
        QuaHan = EHopDong_CommonStatusFilter.QuaHan,
        [Display(Name = "Chậm lãi")]
        ChamLai = EHopDong_CommonStatusFilter.ChamLai,
        [Display(Name = "Kết thúc")]
        KetThuc = EHopDong_CommonStatusFilter.KetThuc,
        [Display(Name = "Đã xóa")]
        DaXoa = EHopDong_CommonStatusFilter.DaXoa,
        [Display(Name = "Nợ xấu")]
        NoXau = EHopDong_CommonStatusFilter.ChoThanhLy,
        [Display(Name = "Đang vay")]
        DangVay
    }

    public enum EHopDong_GopVonStatusFilter : byte
    {
        [Display(Name = "Đúng hẹn")]
        DungHen = EHopDong_CommonStatusFilter.DungHen,
        [Display(Name = "Quá hạn")]
        QuaHan = EHopDong_CommonStatusFilter.QuaHan,
        [Display(Name = "Chậm lãi")]
        ChamLai = EHopDong_CommonStatusFilter.ChamLai,
        [Display(Name = "Kết thúc")]
        KetThuc = EHopDong_CommonStatusFilter.KetThuc
    }
    #endregion
    public enum EHopDong_ChungTuType : byte
    {
        HopDong = 1,
        KhachHang
    }
}
