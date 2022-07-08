using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.HopDong;
using BaseSource.ViewModels.HopDong_GianHan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ApiIntegration.WebApi.HopDong_GianHan
{
    public interface IHopDong_GianHanApiClient
    {
        Task<ApiResult<List<HopDong_GiaHanVm>>> GetByHopDong(int hopDongId);
        Task<ApiResult<string>> GiaHan(GiaHanRequestVm model);
    }
}
