using BaseSource.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.Data.Entities
{
    public class CauHinhHangHoa
    {
        public int Id { get; set; }
        public ELinhVucHangHoa LinhVuc { get; set; }
        public string MaTS { get; set; }
        public string Ten { get; set; }
        public bool IsPublish { get; set; }
        public EHinhThucLai HinhThucLai { get; set; }
        public bool IsThuLaiTruoc { get; set; }
        public long SoTienCam { get; set; }
        public int Lai { get; set; }
        public int KyLai { get; set; }
        public int SoNgayVay { get; set; }
        public int SoNgayQuaHan { get; set; }
        public int? CuaHangId { get; set; }
        public string ListThuocTinh { get; set; }

        public virtual CuaHang CuaHang { get; set; }
    }
}
