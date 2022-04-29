using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ViewModels.User
{
    public class RegisterRequestVm
    {

        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Password minimum 6 characters", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Password minimum 6 characters", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
