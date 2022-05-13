using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.Data.Entities
{
    public class HopDong_DebtNote
    {
        public int Id { get; set; }
        public int HopDongId { get; set; }
        public string Note { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual HopDong HopDong { get; set; }
    }
}
