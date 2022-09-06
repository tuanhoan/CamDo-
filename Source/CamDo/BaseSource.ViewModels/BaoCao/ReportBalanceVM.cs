using BaseSource.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ViewModels.BaoCao
{
    public class ReportBalanceRequest 
    {
        public DateTime? FormDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string UserId { get; set; }
        public int? LoaiHopDong { get; set; }
    }
    public class ReportBalanceVM
    {
        public Summary TienDauNgay { get; set; }
        public Summary CamDo { get; set; }
        public Summary VayLai { get; set; }
        public Summary BatHo { get; set; }
        public Summary ThuHoatDong { get; set; }
        public Summary ChiHoatDong { get; set; }
        public Summary NguonVon { get; set; }
        public Summary TienMatConLai { get; set; }
        public List<GiaoDich> GiaoDichs { get; set; }
    }
    public class Summary
    {
        public double Thu { get; set; }
        public double Chi { get; set; }
        public double Total { get; set; }
    }

    public class GiaoDich
    {
        public ELoaiHopDong LoaiHopDong { get; set; }
        public string MaHopDong { get; set; }
        public string NguoiGD { get; set; }
        public string KhachHang { get; set; }
        public DateTime NgayGiaoDich { get; set; }
        public string DienDai { get; set; }
        public double DaThu { get; set; }
        public double DaChi { get; set; }
        public string GhiChu { get; set; }
    }
}
