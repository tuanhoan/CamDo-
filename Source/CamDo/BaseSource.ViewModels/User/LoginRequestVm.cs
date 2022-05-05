using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ViewModels.User
{
    public class LoginRequestVm
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public IList<AuthenticationScheme> ExternalLogins { get; set; }
    }
}
