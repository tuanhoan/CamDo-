using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.HopDong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ApiIntegration.WebApi.HopDong_ChuocDo
{
    public interface IHopDong_ChuocDoApiClient
    {
        Task<ApiResult<HopDong_ChuocDoVm>> GetInfoChuocDo(HopDong_ChuocDoRequestVm model);
        Task<ApiResult<string>> ChuocDo(HopDong_ChuocDoVm model);
    }
}
