using BaseSource.Shared.Constants;
using BaseSource.Utilities.Helper;
using BaseSource.ViewModels.Admin;
using BaseSource.ViewModels.Common;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BaseSource.ApiIntegration.AdminApi.LienHe
{
    public class LienHeAdminApiClient : ILienHeAdminApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public LienHeAdminApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ApiResult<string>> Delete(int id)
        {
            var dic = new Dictionary<string, string>()
            {
                { "id", id.ToString() }
            };

            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsyncFormUrl<ApiResult<string>>("/api/admin/LienHe/Delete", dic);
        }

        public async Task<ApiResult<LienHeAdminVm>> GetById(int id)
        {
            var obj = new
            {
                id = id
            };
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<LienHeAdminVm>>("/api/admin/LienHe/GetById", obj);
        }

        public async Task<ApiResult<PagedResult<LienHeAdminVm>>> GetPagings(GetLienHePagingRequest_Admin model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<PagedResult<LienHeAdminVm>>>("/api/admin/LienHe/GetPagings", model);
        }
    }
}
