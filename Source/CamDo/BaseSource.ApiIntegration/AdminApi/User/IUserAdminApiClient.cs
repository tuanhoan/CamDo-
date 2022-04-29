using BaseSource.ViewModels.Admin;
using BaseSource.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ApiIntegration.AdminApi
{
    public interface IUserAdminApiClient
    {
        Task<ApiResult<PagedResult<UserVm>>> GetPagings(GetUserPagingRequest_Admin model);

        Task<ApiResult<UserVm>> GetById(string id);
        Task<ApiResult<RoleAssignVm>> GetUserRoles(string id);
        Task<ApiResult<string>> RoleAssign(RoleAssignVm model);
    }
}
