using BaseSource.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ViewModels.CuaHang
{
    public class QuyCuaHangVm
    {
        public double Money { get; set; }
        public string Note { get; set; }
        public long Id { get; set; }
        public byte ActionType { get; set; }
        public byte LogType { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
    public class CreateQuyCuaHang
    {
        [Required(ErrorMessage = "Vui lòng nhập số tiền")]
        public double Money { get; set; }
        public string Note { get; set; }
        public int Id { get; set; }
        public byte ActionType { get; set; }
        public EQuyTienCuaHang_LogType LogType { get; set; }

    }

   
}
