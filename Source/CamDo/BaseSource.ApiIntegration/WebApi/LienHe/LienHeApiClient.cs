using BaseSource.Shared.Constants;
using BaseSource.Utilities.Helper;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.LienHe;
using System.Net.Http;
using System.Threading.Tasks;

namespace BaseSource.ApiIntegration.WebApi.LienHe
{
    public class LienHeApiClient : ILienHeApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public LienHeApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<ApiResult<string>> Create(CreateLienHeVm model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<string>>("/api/LienHe/Create", model);
        }
    }
}
