using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.HD_PaymentLog;
using BaseSource.ViewModels.HopDong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ApiIntegration.WebApi.HopDong
{
    public interface IHopDongApiClient
    {
        Task<ApiResult<PagedResult<HopDongVm>>> GetPagings(GetHopDongPagingRequest model);
        Task<ApiResult<string>> Create(CreateHopDongVm model);
        Task<ApiResult<HopDongVm>> GetById(int id);
        Task<ApiResult<string>> Edit(EditHopDongVm model);
        Task<ApiResult<string>> NoLai(HopDongNoLaiVm model);
        Task<ApiResult<string>> TraNo(HopDongTraNoVm model);
    }
}
