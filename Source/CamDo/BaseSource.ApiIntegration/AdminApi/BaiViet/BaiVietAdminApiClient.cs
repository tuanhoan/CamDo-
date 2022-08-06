using BaseSource.Shared.Constants;
using BaseSource.Utilities.Helper;
using BaseSource.ViewModels.Admin;
using BaseSource.ViewModels.Common;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BaseSource.ApiIntegration.AdminApi.BaiViet
{
    public class BaiVietAdminApiClient : IBaiVietAdminApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BaiVietAdminApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ApiResult<string>> Create(CreateBaiVietAdminVm model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<string>>("/api/admin/BaiViet/Create", model);
        }

        public async Task<ApiResult<string>> Delete(int id)
        {
            var dic = new Dictionary<string, string>()
            {
                { "id", id.ToString() }
            };

            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsyncFormUrl<ApiResult<string>>("/api/admin/BaiViet/Delete", dic);
        }

        public async Task<ApiResult<string>> Edit(EditBaiVietAdminVm model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<string>>("/api/admin/BaiViet/Edit", model);
        }

        public async Task<ApiResult<BaiVietAdminVm>> GetById(int id)
        {
            var obj = new
            {
                id = id
            };
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<BaiVietAdminVm>>("/api/admin/BaiViet/GetById", obj);
        }

        public async Task<ApiResult<PagedResult<BaiVietAdminVm>>> GetPagings(GetBaiVietPagingRequest_Admin model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<PagedResult<BaiVietAdminVm>>>("/api/admin/BaiViet/GetPagings", model);
        }
    }
}
