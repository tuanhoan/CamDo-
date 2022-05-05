using BaseSource.ViewModels.Admin;
using BaseSource.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ApiIntegration.AdminApi.MoTaHinhThucLai
{
    public interface IMoTaHinhThucLaiAdmiApiClient
    {
        Task<ApiResult<PagedResult<MoTaHinhThucLaiAdminVm>>> GetPagings(GetMoTaHinhThucLaiPagingRequest_Admin model);
        Task<ApiResult<string>> Create(CreateMoTaHinhThucLaiAdminVm model);
        Task<ApiResult<MoTaHinhThucLaiAdminVm>> GetById(int id);
        Task<ApiResult<string>> Edit(EditMoTaHinhThucLaiAdminVm model);
        Task<ApiResult<string>> Delete(int id);
    }
}
