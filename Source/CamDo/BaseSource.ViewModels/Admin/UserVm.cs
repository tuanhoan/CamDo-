using BaseSource.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ViewModels.Admin
{
    public class GetUserPagingRequest_Admin : PageQuery
    {
        public string UserName { get; set; }
        public string Email { get; set; }
    }

    public class UserVm
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public IList<string> Roles { get; set; }

        public DateTime JoinedDate { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
    }

    public class UserShop : UserVm
    {
        public int ShopId { get; set; } 
    }
    public class CreateUserAdminVm
    {
        [Display(Name = "Tài Khoản")]
        [Required(ErrorMessage = "Vui lòng nhập UserName")]
        [RegularExpression("^[A-z0-9]+$", ErrorMessage = "UserName không được chứae ký tự đặc biệt")]
        public string UserName { get; set; }
        [Display(Name = "Họ tên")]
        [Required(ErrorMessage = "Vui lòng nhập họ tên")]
        public string FullName { get; set; }
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [MinLength(6, ErrorMessage = "Mật khẩu tối thiểu 6 ký tự")]
        public string Password { get; set; }
        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
    public class EditUserAdminVm : CreateUserAdminVm
    {
        public string Id { get; set; }
    }

    public class RoleAssignVm
    {
        [Required]
        public string Id { get; set; }
        public List<SelectItem> Roles { get; set; } = new List<SelectItem>();
    }

    public class EditUserShop : CreateUserAdminVm
    {
        public string Id { get; set; }
        [Display(Name = "Cửa Hàng")]
        public int CuaHangId { get; set; }
    }

}
