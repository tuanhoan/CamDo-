using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ViewModels.BaoCao
{
    public class ProfitVM
    {
        public int HDMoi { get; set; }
        public double LoiNhuan { get; set; }
        public List<ProfitVMDetail> profitVMDetails { get; set; }
    }
    public class ProfitVMDetail
    {
        public string Loai { get; set; }
        public int Tong { get; set; }
        public int Moi { get; set; }
        public int Cu { get; set; }
        public int Dong { get; set; }
        public int TraLai { get; set; }
        public int NoLai { get; set; }
        public int QuaLai { get; set; }
        public int ThanhLy { get; set; }
        public double TongTienChoVay { get; set; }
        public double DangChoVay { get; set; }
        public double LoiNhuan { get; set; }
        public double KhachNo { get; set; }
    }
}
