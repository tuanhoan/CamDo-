using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.Data.Entities
{
    public class GoiSanPham
    {
        public int Id { get; set; }
        public string Ten { get; set; }
        public int SoThang { get; set; }
        public double TongTien { get; set; }
        public string KhuyenMai { get; set; }
        public string MoTa { get; set; }
        public string UserIdCreated { get; set; }
        public DateTime CreatedTime { get; set; }
        public string UserIdUpdate { get; set; }
        public DateTime? UpdatedTime { get; set; }
    }
}
