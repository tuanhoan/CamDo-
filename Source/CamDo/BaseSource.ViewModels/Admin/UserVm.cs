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

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public IList<string> Roles { get; set; }

        public DateTime JoinedDate { get; set; }
        public DateTime LockoutEndDateUtc { get; set; }
    }

    public class RoleAssignVm
    {
        [Required]
        public string Id { get; set; }
        public List<SelectItem> Roles { get; set; } = new List<SelectItem>();
    }
}
