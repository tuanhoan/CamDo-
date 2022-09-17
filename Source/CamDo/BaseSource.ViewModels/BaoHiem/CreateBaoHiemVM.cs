using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ViewModels.BaoHiem
{
    public class CreateBaoHiemVM
    {
        public int KhachHangId { get; set; }
        public string TenKhachHang { get; set; }
        public string SDT { get; set; }
        public DateTime NgaySinh { get; set; }
        public bool GioiTinh { get; set; }
        public string CMND { get; set; }
        public DateTime NgayCap { get; set; }
        public string NoiCap { get; set; }
        public string Email { get; set; }
        public string MST { get; set; }
        public string Address { get; set; }
        public string GoiBaoHiem { get; set; }
        public DateTime NgayMua { get; set; }
        public string IMGPath { get; set; } 
    }
}
