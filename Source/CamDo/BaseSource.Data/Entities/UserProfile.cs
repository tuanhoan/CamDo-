using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.Data.Entities
{
    public class UserProfile
    {
        public string UserId { get; set; }

        public string CustomId { get; set; }

        public string FullName { get; set; }

        public DateTime JoinedDate { get; set; }

        // object
        public virtual AppUser AppUser { get; set; }
        public virtual List<CuaHang> CuaHangs { get; set; }
    }
}
