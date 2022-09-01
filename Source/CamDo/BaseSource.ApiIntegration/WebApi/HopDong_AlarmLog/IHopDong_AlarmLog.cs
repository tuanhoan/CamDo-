using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.HopDong_AlarmLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ApiIntegration.WebApi.HopDong_AlarmLog
{
    public interface IHopDong_AlarmLog
    {
        Task<ApiResult<List<HopDong_AlarmLogVm>>> GetHopDong_AlarmLog(int hopDongId);
        Task<ApiResult<string>> Create(CreateHopDong_AlarmLogVm model);
        Task<ApiResult<PagedResult<HopDong_AlarmLogVm>>> GetPagings(HopDong_AlarmLogRQ model);
    }
}

