using BaseSource.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ViewModels.CuaHang
{
    public class GetCuaHangPagingRequest : PageQuery
    {
        public string Ten { get; set; }
        public string Status { get; set; }
    }
    public class CuaHangVm
    {
        public int Id { get; set; }
        public string Ten { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public string TenNguoiDaiDien { get; set; }
        public long VonDauTu { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedTime { get; set; }
    }
    public class CreateCuaHangVm
    {
        [Display(Name = "Tên cửa hàng")]
        [Required(ErrorMessage = "Vui lòng nhập tên cửa hàng")]
        public string TenCuaHang { get; set; }
        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ")]
        public string DiaChi { get; set; }
        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        public string SDT { get; set; }
        [Display(Name = "Người đại diện")]
        public string TenNguoiDaiDien { get; set; }
        [Display(Name = "Vốn đầu tư")]
        [Required(ErrorMessage = "Vui lòng nhập vốn đầu tư")]
        [Range(0.1, long.MaxValue, ErrorMessage = "Vui lòng nhập vốn đâu tư")]
        public long VonDauTu { get; set; }
        [Display(Name = "Hoạt động")]
        public bool IsActive { get; set; }
    }
    public class EditCuaHangVm : CreateCuaHangVm
    {
        public int Id { get; set; }
    }

    #region Đăng ký cửa hàng

    public class RegisterCuaHangVm
    {
        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập")]
        [RegularExpression("^[A-z0-9]+$", ErrorMessage = "Username không được chứa ký tự đặc biệt")]
        public string UserName { get; set; }
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        public string Password { get; set; }
        [Display(Name = "Họ tên")]
        [Required(ErrorMessage = "Vui lòng nhập họ tên")]
        public string FullName { get; set; }
        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ")]
        public string Address { get; set; }
        [Display(Name = "Tên cửa hàng")]
        [Required(ErrorMessage = "Tên cửa hàng")]
        public string TenCuaHang { get; set; }

        private long _vonDauTu;
        [Display(Name = "Vốn đầu tư")]
        [Required(ErrorMessage = "Vui lòng nhập vốn đầu tư")]
        public long VonDauTu
        {
            get
            {
                return _vonDauTu = 1000000000;
            }
            set
            {
                _vonDauTu = value;

            }
        }
    }
    #endregion
}
