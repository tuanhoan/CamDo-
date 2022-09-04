using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ViewModels.BaoCao
{
    public class ReportBalanceVM
    {
        public Summary TienDauNgay { get; set; }
        public Summary CamDo { get; set; }
        public Summary VayLai { get; set; }
        public Summary BatHo { get; set; }
        public Summary ThuHoatDong { get; set; }
        public Summary ChiHoatDong { get; set; }
        public Summary NguonVon { get; set; }
        public Summary TienMatConLai { get; set; }
    }
    public class Summary
    {
        public double Thu { get; set; }
        public double Chi { get; set; }
        public double Total { get; set; }
    }
}
