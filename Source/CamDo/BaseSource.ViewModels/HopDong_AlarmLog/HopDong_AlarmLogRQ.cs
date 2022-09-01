using BaseSource.Shared.Enums;
using BaseSource.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ViewModels.HopDong_AlarmLog
{
    public class HopDong_AlarmLogRQ : PageQuery
    {
        public ELoaiHopDong Type { get; set; }
    }
    
}
