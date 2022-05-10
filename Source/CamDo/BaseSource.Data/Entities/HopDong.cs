using BaseSource.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.Data.Entities
{
    public class HopDong
    {
        public int Id { get; set; }
        public int KhachHangId { get; set; }
        public int HangHoaId { get; set; }
        public string HangHoa_Ten { get; set; }
        public string HD_MA { get; set; }
        public double HD_TongTien { get; set; }
        public EHinhThucLai HD_HinhThucLai { get; set; }
        public bool HD_IsTraTruoc { get; set; }
        public int HD_TongThoiGianVay { get; set; }
        public int HD_KyLai { get; set; }
        public double HD_LaiSuat { get; set; }
        public DateTime HD_NgayVay { get; set; }
        public string HD_GhiChu { get; set; }
        public string UserIdCreated { get; set; }
        public string UserIdAssigned { get; set; }
        public string HangHoa_ListThuocTinh { get; set; }

    }
}
