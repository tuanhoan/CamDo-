using BaseSource.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.Data.Entities
{
    public class MoTaHinhThucLai
    {
        public int Id { get; set; }
        public EHinhThucLai? HinhThucLai { get; set; }
        public string TyLeLai { get; set; }
        public string MoTaKyLai { get; set; }
        public EThoiGianVay ThoiGian { get; set; }
    }
}
