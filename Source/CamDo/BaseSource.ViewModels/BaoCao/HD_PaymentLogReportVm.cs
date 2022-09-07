using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ViewModels.BaoCao
{
    public class HD_PaymentLogReportVm
    {
        public string MaHD { get; set; }
        public string TenKhachHang { get; set; }
        public int KhachHangId { get;set; }
        public string TenHang { get; set; }
        public double TienVay { get; set; }
        public string NguoiGiaoDich { get; set; }
        public DateTime? NgayGiaoDich { get; set; }
        public double TienLai { get; set; }
        public double TienKhac { get; set; }
        public double TongLai { get; set; }
        public string LoaiGiaoDich { get; set; }
    }
}
