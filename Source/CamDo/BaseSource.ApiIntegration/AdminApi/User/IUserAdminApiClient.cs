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

        Task<ApiResult<UserVm>> GetById(string userId);
        Task<ApiResult<RoleAssignVm>> GetUserRoles(string userId);
        Task<ApiResult<string>> RoleAssign(RoleAssignVm model);
        Task<ApiResult<string>> Create(CreateUserAdminVm model);
        Task<ApiResult<string>> Edit(EditUserAdminVm model);
        Task<ApiResult<string>> LockUnLockUser(string userId);
        Task<ApiResult<string>> ResetPassword(string userId);
    }
}
