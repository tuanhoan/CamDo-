using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.Data.Entities
{
    public class ReportCustomer
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string CMND { get; set; }
        public string Address { get; set; }
        public string Reason { get; set; }
        public string UserReport { get; set; }
        public string UserId { get; set; }
        public int CuaHangId { get; set; }
        public DateTime CreatedTime { get; set; }
        public string UpdateById { get; set; }
        public DateTime? UpdatedTime { get; set; }
    }
}
