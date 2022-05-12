using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.Data.Entities
{
    public class CuaHang
    {
        public int Id { get; set; }
        public string Ten { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public string TenNguoiDaiDien { get; set; }
        public long VonDauTu { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedTime { get; set; }
        public string UserId { get; set; }

        public virtual UserProfile UserProfile { get; set; }
        public virtual List<KhachHang> KhachHangs { get; set; }
        public virtual List<CauHinhHangHoa> CauHinhHangHoas { get; set; }
    }
}
