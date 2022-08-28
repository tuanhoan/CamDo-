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

    }
    public class CreateQuyCuaHang
    {
        [Required(ErrorMessage = "Vui lòng nhập số tiền")]
        public float Money { get; set; }
        public string Note { get; set; }
        public int Id { get; set; }
        public byte ActionType { get; set; }
        public EQuyTienCuaHang_LogType LogType { get; set; }

    }
}
