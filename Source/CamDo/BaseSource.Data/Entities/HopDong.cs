using BaseSource.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.Data.Entities
{
    public class HopDong
    {
        public int Id { get; set; }
        public int CuaHangId { get; set; }
        public int KhachHangId { get; set; }
        public int? HangHoaId { get; set; }
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
        public string HD_GhiChu { get; set; }
        public string ListThuocTinhHangHoa { get; set; }
        public string ImageList { get; set; }
        public double TongTienLai { get; set; }
        public double TongTienLaiDaThanhToan { get; set; }
        public DateTime? NgayDongLaiGanNhat { get; set; }
        public DateTime? NgayDongLaiTiepTheo { get; set; }
        public double TongTienVayHienTai { get; set; }
        public double TongTienGhiNo { get; set; }
        public double TongTienThanhLy { get; set; }
        public double TongTienDaThanhToan { get; set; }
        public bool IsNoXau_ChoThanhLy { get; set; }
        public DateTime? NgayThanhLy { get; set; }
        public DateTime? NgayTatToan { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string UserIdCreated { get; set; }
        public string UserIdAssigned { get; set; }
        public byte HD_Status { get; set; }
        public double TienLaiToiNgayHienTai { get; set; }
        public int SoNgayLaiToiHienTai { get; set; }
        public double TongTienChuoc { get; set; }

        public virtual CuaHang CuaHang { get; set; }
        public virtual List<HopDong_VayRutGoc> HopDong_VayRutGocs { get; set; }
        public virtual List<HopDong_GiaHan> HopDong_GiaHans { get; set; }
        public virtual List<HopDong_PaymentLog> HopDong_PaymentLogs { get; set; }
        public virtual List<HopDong_AlarmLog> HopDong_AlarmLogs { get; set; }
        public virtual List<CuaHang_TransactionLog> CuaHang_TransactionLogs { get; set; }
        public virtual List<HopDong_DebtNote> HopDong_DebtNotes { get; set; }
    }
}
