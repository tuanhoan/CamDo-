using BaseSource.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ViewModels.Admin
{
    public class GoiSanPham_LichSuMuaQr : PageQuery
    {
        public string Info { get; set; }
    }
    public class GoiSanPham_LichSuMuaVM 
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int GoiSanPhamId { get; set; }
        public string TenGoi { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double TongTien { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }      


    }
    public class GoiSanPham_LichSuMuaCreate
    {
        public string UserId { get; set; }
        public int GoiSanPhamId { get; set; }
        public string TenGoi { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double TongTien { get; set; }
    }
    public class GoiSanPham_LichSuMuaEdit : GoiSanPham_LichSuMuaCreate
    {
        public int Id { get; set; }
    }
}
