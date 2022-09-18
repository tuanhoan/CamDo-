using BaseSource.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ViewModels.BaoHiem
{
    public partial class BaoHiemVm
    {
        public int Id { get; set; }
        public int CuaHangId { get; set; }
        public string CuaHangName { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Ten { get; set; }
        public string SDT { get; set; }
        public double GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public double CMND { get; set; }
        public DateTime CMND_NgayCap { get; set; }
        public string CMND_NoiCap { get; set; }
        public string Email { get; set; }
        public string MST { get; set; }
        public string DiaChi { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ImageList { get; set; }
        public double TienBaoHiem { get; set; }
        public double TienPhi { get; set; }
        public double TienChietKhau { get; set; }
        public double TongTien { get; set; }
        public ETypeBaoHiem Type { get; set; }
    }
}
