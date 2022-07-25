using BaseSource.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ViewModels.HopDong_AlarmLog
{
    public class HopDong_AlarmLogVm
    {
        public int Id { get; set; }
        public int HopDongId { get; set; }
        public DateTime? AlarmDate { get; set; }
        public string Note { get; set; }
        public bool IsDisable { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    public class CreateHopDong_AlarmLogVm
    {
        [Required]
        public int HopDongId { get; set; }
        public string Note { get; set; }
        public DateTime AlarmDate { get; set; }
        public bool IsDisable { get; set; }
    }
}
