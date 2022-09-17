using BaseSource.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ViewModels.BaoHiem
{
    public  class BaoHiemCreate
    {
        public int CuaHangId { get; set; }
        public string UserId { get; set; }
        [Display(Name = "Tên khách hàng")]
        [Required(ErrorMessage = "Vui lòng nhập Tên khách hàng")]
        public string Ten { get; set; }
        [Display(Name = "Số điện thoại")]
        [MinLength(9)]
        [Required(ErrorMessage = "Vui lòng nhập Số điện thoại")]
        public string SDT { get; set; }
        [Display(Name = "Giới tính")]
        [Required(ErrorMessage = "Vui lòng nhập Giới tính")]
        public double GioiTinh { get; set; }
        [Display(Name = "Ngày Sinh")]
        [Required(ErrorMessage = "Vui lòng nhập Ngày sinh")]
        public DateTime NgaySinh { get; set; }
        [Display(Name = "Số CMND/Hộ chiếu")]
        [Required(ErrorMessage = "Vui lòng nhập Số CMND/Hộ chiếu")]
        public double CMND { get; set; }
        public DateTime CMND_NgayCap { get; set; }
        public string CMND_NoiCap { get; set; }
        public string Email { get; set; }
        public string MST { get; set; }
        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Vui lòng nhập Địa chỉ")]
        public string DiaChi { get; set; }
        [Display(Name = "Ngày mua")]
        [Required(ErrorMessage = "Vui lòng nhập Ngày mua")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Thời Gian Mua")]
        [Required(ErrorMessage = "Vui lòng nhập Thời Gian Mua")]
        public int ThoiGianMua { get; set; }
        [Display(Name = "Ảnh CMND/CCCD")]
        [Required(ErrorMessage = "Vui lòng nhập Ảnh CMND/CCCD")]
        public string ImageList { get; set; }
        [Display(Name = "Gói Bảo Hiểm")]
        [Required(ErrorMessage = "Vui lòng chọn Gói Bảo Hiểm")]
        public double TienBaoHiem { get; set; }
        public double TienPhi { get; set; }
        public double TienChietKhau { get; set; }
        public double TongTien { get; set; }
        public ETypeBaoHiem Type { get; set; }
    }
}
