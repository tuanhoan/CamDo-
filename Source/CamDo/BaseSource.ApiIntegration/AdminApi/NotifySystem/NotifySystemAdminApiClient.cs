using BaseSource.ViewModels.Admin;
using BaseSource.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BaseSource.Utilities.Helper;
using BaseSource.Shared.Constants;

namespace BaseSource.ApiIntegration.AdminApi.NotifySystem
{
    public class NotifySystemAdminApiClient : INotifySystemAdminApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public NotifySystemAdminApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<ApiResult<string>> Create(CreateNotifySystemVm model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<string>>("/api/admin/NotifySystem/Create", model);
        }

        public async Task<ApiResult<string>> Delete(int id)
        {
            var dic = new Dictionary<string, string>()
            {
                { "id", id.ToString() }
            };

            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsyncFormUrl<ApiResult<string>>("/api/admin/NotifySystem/Delete", dic);
        }

        public async Task<ApiResult<string>> Edit(EditNotifySystemVm model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<string>>("/api/admin/NotifySystem/Edit", model);
        }

        public async Task<ApiResult<NotifySystemAdminVm>> GetById(int id)
        {
            var obj = new
            {
                id = id
            };
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<NotifySystemAdminVm>>("/api/admin/NotifySystem/GetById", obj);
        }

        public async Task<ApiResult<PagedResult<NotifySystemAdminVm>>> GetPagings(GetNotifySystemPagingRequest_Admin model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<PagedResult<NotifySystemAdminVm>>>("/api/admin/NotifySystem/GetPagings", model);
        }
    }
}
