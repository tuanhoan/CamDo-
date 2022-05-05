using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.Shared.Enums
{
    public enum ELinhVucHangHoa : byte
    {
        [Display(Name = "Cầm đồ")]
        Camdo = 1,
        [Display(Name = "Vay lãi")]
        Vaylai
    }
    public enum EHinhThucLai : byte
    {
        [Display(Name = "Lãi ngày (k/triệu)")]
        LaiNgayKTrieu = 1,
        [Display(Name = "Lãi ngày (k/ngày)")]
        LaiNgayKNgay,
        [Display(Name = "Lãi tháng(%)(30 ngày)")]
        LaiThangPhanTram,
        [Display(Name = "Lãi tháng (định kì)")]
        LaiThangDinhKi,
        [Display(Name = "Lãi tuần (%)")]
        LaiTuanPhanTram,
        [Display(Name = "Lãi tuần (VNĐ)")]
        LaiTuanVND
    }

}
