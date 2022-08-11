using BaseSource.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ViewModels.HopDong
{
    public class InDongLaiResponseVm
    {
        public string MaHD { get; set; }
        public string TenNhanVien { get; set; }
        public string TenKhachHang { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public double TienLai { get; set; }
        public DateTime? NgayDongLaiTiepTheo { get; set; }
    }
    public class InChuocDoResponseVm
    {
        public string MaHD { get; set; }
        public string TenNhanVien { get; set; }
        public string TenKhachHang { get; set; }
        public string TenTaiSan { get; set; }
        public DateTime NgayVay { get; set; }
        public DateTime? NgayChuoc { get; set; }
        public double TienVay { get; set; }
        public double TienChuoc { get; set; }
    }

    public class HopDongPrintDefaulVm
    {
        public ELoaiHopDong LoaiHopDong { get; set; }
        public ECamDo_HopDongPrintTemplate CamDo_HopDongPrintTemplate { get; set; }
        public EVayLai_HopDongPrintTemplate VayLai_HopDongPrintTemplate { get; set; }
    }
}
