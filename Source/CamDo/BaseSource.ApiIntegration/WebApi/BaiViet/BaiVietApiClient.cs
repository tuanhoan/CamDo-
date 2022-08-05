using BaseSource.Shared.Constants;
using BaseSource.Utilities.Helper;
using BaseSource.ViewModels.BaiViet;
using BaseSource.ViewModels.Common;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BaseSource.ApiIntegration.WebApi.BaiViet
{
    public class BaiVietApiClient : IBaiVietApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BaiVietApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ApiResult<List<BaiVietVm>>> GetAll()
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<List<BaiVietVm>>>("/api/BaiViet/GetAll");
        }

        public async Task<ApiResult<BaiVietVm>> GetByUrl(string url)
        {
            var obj = new
            {
                url = url
            };
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<BaiVietVm>>("/api/BaiViet/GetByUrl", obj);
        }
    }
}
