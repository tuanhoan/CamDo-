using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.Data.Entities
{
    public class Friendship 
    {
        public string UserIdRequest { get; set; }
        public string UserIdReceive { get; set; }
        public string IsConfirm { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
