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

namespace BaseSource.ApiIntegration.AdminApi.FeedBack
{
    public class FeedBackAdminApiClient : IFeedBackAdminApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public FeedBackAdminApiClient(IHttpClientFactory httpClientFactory)
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
            return await client.PostAsyncFormUrl<ApiResult<string>>("/api/admin/FeedBack/Delete", dic);
        }

        public async Task<ApiResult<PagedResult<FeedBackAdminVm>>> GetPagings(GetFeedBackPagingRequest_Admin model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<PagedResult<FeedBackAdminVm>>>("/api/admin/FeedBack/GetPagings", model);
        }
    }
}
