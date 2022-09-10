using BaseSource.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ViewModels.BaoCao
{
    public class ReportPawnHoldingVm
    {
         public ELoaiHopDong LoaiHopDong { get; set; }
         public string MaHD { get; set; }
         public string TenKhachHang { get; set; }
         public string TenHang { get; set; }
         public string NgayVay { get; set; }
         public double TienVay { get; set; }
         public EHopDong_CamDoStatusFilter TinhTrang { get; set; }
    }
}
