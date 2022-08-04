using BaseSource.ViewModels.Admin;
using BaseSource.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ApiIntegration.AdminApi.LienHe
{
    public interface ILienHeAdminApiClient
    {
        Task<ApiResult<PagedResult<LienHeAdminVm>>> GetPagings(GetLienHePagingRequest_Admin model);
        Task<ApiResult<LienHeAdminVm>> GetById(int id);
        Task<ApiResult<string>> Delete(int id);
    }
}
