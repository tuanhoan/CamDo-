using BaseSource.Shared.Enums;
using BaseSource.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ViewModels.MoTaHinhThucLai
{
    public class GetMoTaHinhThucLaiPagingRequest : PageQuery
    {
        public int HinhThucLai { get; set; }
    }
    public class MoTaHinhThucLaiVm
    {
        public int Id { get; set; }
        public EHinhThucLai? HinhThucLai { get; set; }
        public string TyLeLai { get; set; }
        public string MoTaKyLai { get; set; }
        public EThoiGianVay ThoiGian { get; set; }
        public string ThoiGianDisplay { get; set; }
    }
}
