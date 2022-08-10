using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ViewModels.User
{
    public class UserInfoResponse
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<string> Roles { get; set; }
        public DateTime? JoinedDate { get; set; }
        public double Blance { get; set; }

    }
}
