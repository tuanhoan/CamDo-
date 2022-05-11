using BaseSource.Shared.Constants;
using BaseSource.ViewModels.Admin;
using BaseSource.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BaseSource.Utilities.Helper;

namespace BaseSource.ApiIntegration.AdminApi
{
    public class UserAdminApiClient : IUserAdminApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UserAdminApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ApiResult<PagedResult<UserVm>>> GetPagings(GetUserPagingRequest_Admin model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<PagedResult<UserVm>>>("/api/admin/User/GetPagings", model);
        }


        public async Task<ApiResult<UserVm>> GetById(string id)
        {
            var obj = new
            {
                id = id
            };
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<UserVm>>("/api/admin/User/GetById", obj);
        }

        public async Task<ApiResult<RoleAssignVm>> GetUserRoles(string id)
        {
            var obj = new
            {
                id = id
            };
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<RoleAssignVm>>("/api/admin/User/GetUserRoles", obj);
        }

        public async Task<ApiResult<string>> RoleAssign(RoleAssignVm model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<string>>("/api/admin/User/RoleAssign", model);
        }

        public async Task<ApiResult<string>> Create(CreateUserAdminVm model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<string>>("/api/admin/User/Create", model);
        }

        public async Task<ApiResult<string>> Edit(EditUserAdminVm model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<string>>("/api/admin/User/Edit", model);
        }

        public async Task<ApiResult<string>> LockUnLockUser(string id)
        {
            var dic = new Dictionary<string, string>()
            {
                { "id", id },
            };

            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsyncFormUrl<ApiResult<string>>("/api/admin/User/LockUnLockUser", dic);
        }
    }
}
