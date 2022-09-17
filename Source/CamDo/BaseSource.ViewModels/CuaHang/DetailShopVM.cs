using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ViewModels.CuaHang
{
    public class DetailShopVM
    {
        public ThongTinVon ThongTinVon { get; set; }
        public ThongTinHopDong ThongTinHopDong { get; set; }
        public ThuChi ThuChi { get; set; }
        public List<HopDong> HopDongs { get; set; }
        public ThongTinLai ThongTinLai { get; set; }
    }
    public class ThongTinVon
    {
        public long VonDauTu { get; set; }
        public double QuyTienMat { get; set; }
        public double TienDangChoVay { get; set; }
    }
    public class ThongTinHopDong
    {
        public int HopDongMo { get; set; }
        public int HopDongDong { get; set; }
        public int TongSoHopDong { get; set; }
    }
    public class ThuChi
    {
        public double TongTienChi { get; set; }
        public double TongTienThu { get; set; }
        public double TongTienKhachNo { get; set; }
    }
    public class HopDong
    {
        public string Ten { get; set; }
        public int SoHD { get; set; }
        public int HopDongMo { get; set; }
        public int HopDongDong { get; set; }
        public double TienChoVay { get; set; }
        public double LaiDuKien { get; set; }
        public double LaiDaThu { get; set; }
        public double TienKhachNo { get; set; }
    }
    public class ThongTinLai
    {
        public double LaiDuKien { get; set; }
        public double LaiDaThu { get; set; }
    }
}
