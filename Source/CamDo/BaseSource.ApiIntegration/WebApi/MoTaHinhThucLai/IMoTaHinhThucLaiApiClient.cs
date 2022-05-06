using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.MoTaHinhThucLai;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ApiIntegration.WebApi.MoTaHinhThucLai
{
    public interface IMoTaHinhThucLaiApiClient
    {
        Task<ApiResult<PagedResult<MoTaHinhThucLaiVm>>> GetPagings(GetMoTaHinhThucLaiPagingRequest model);
    }
}
