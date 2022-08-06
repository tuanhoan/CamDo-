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
}
