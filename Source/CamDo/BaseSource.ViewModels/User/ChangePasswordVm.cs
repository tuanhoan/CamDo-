using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ViewModels.User
{
    public class ChangePasswordVm
    {
        [Display(Name ="Mật khẩu cũ")]
        [Required(ErrorMessage ="Vui lòng nhập mật khẩu cũ")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu mới")]
        [StringLength(50, ErrorMessage = "Mật khẩu tối thiểu 6 ký tự", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu mới")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập xác nhận mật khẩu")]
        [StringLength(50, ErrorMessage = "Mật khẩu tối thiểu 6 ký tự", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nhập lại mật khẩu")]
        [Compare("NewPassword",ErrorMessage = "Mật khẩu xác nhận không khớp với mật khẩu mới")]
        public string ConfirmPassword { get; set; }
    }
}
