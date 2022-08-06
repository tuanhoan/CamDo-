using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ViewModels.HopDong
{
    public class HopDong_ChuocDoRequestVm
    {
        [Required]
        public int HopDongId { get; set; }
        public DateTime NgayChuocDo { get; set; }
    }
    public class HopDong_ChuocDoVm
    {
        [Required]
        public int HopDongId { get; set; }
        [Required]
        public DateTime NgayChuocDo { get; set; }
        public double TongTienVay { get; set; }
        public double NoCu { get; set; }
        public double TienLai { get; set; }
        public double TienKhac { get; set; }
        public double TongTienChuoc { get; set; }
        public int TongSoNgayLai { get; set; }
        public DateTime? NgayTatToan { get; set; }
    }
}
