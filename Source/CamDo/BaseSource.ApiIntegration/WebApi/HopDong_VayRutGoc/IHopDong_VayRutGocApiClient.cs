using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.HopDong_VayRutGoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ApiIntegration.WebApi.HopDong_VayRutGoc
{
    public interface IHopDong_VayRutGocApiClient
    {
        Task<ApiResult<List<HopDong_VayRutGocVm>>> GetByHopDong(int hopDongId);
        Task<ApiResult<string>> TraBotGoc(TraBotGocRequestVm model);
        Task<ApiResult<string>> XoaTraBotGoc(int tranLogId);
        Task<ApiResult<string>> VayThem(VayThemRequestVm model);
    }
}
