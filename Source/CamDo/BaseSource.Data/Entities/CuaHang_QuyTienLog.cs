using BaseSource.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.Data.Entities
{
    public class CuaHang_QuyTienLog
    {
        public long Id { get; set; }
        public int CuaHangId { get; set; }
        public EQuyTienCuaHang_LogType LogType { get; set; }
        public byte ActionType { get; set; }
        public double Money { get; set; }
        public string Note { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual CuaHang CuaHang { get; set; }
    }
}
