using BaseSource.ViewModels.Admin;
using BaseSource.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ApiIntegration.AdminApi.NotifySystem
{
    public interface INotifySystemAdminApiClient
    {
        Task<ApiResult<PagedResult<NotifySystemAdminVm>>> GetPagings(GetNotifySystemPagingRequest_Admin model);
        Task<ApiResult<string>> Create(CreateNotifySystemVm model);
        Task<ApiResult<NotifySystemAdminVm>> GetById(int id);
        Task<ApiResult<string>> Edit(EditNotifySystemVm model);
        Task<ApiResult<string>> Delete(int id);
    }
}
