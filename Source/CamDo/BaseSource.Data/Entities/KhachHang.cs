using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.Data.Entities
{
    public class KhachHang
    {
        public int Id { get; set; }
        public string Ten { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string CMND { get; set; }
        public DateTime? CMND_NgayCap { get; set; }
        public string CMND_NoiCap { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public int CuaHangId { get; set; }
        public string ImageList { get; set; }

        public virtual CuaHang CuaHang { get; set; }
    }
}
