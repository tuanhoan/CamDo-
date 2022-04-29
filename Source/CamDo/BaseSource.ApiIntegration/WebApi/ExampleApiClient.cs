using BaseSource.Shared.Constants;
using BaseSource.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using BaseSource.Utilities.Helper;
using BaseSource.ViewModels.Catalog;

namespace BaseSource.ApiIntegration.WebApi
{
    public class ExampleApiClient : IExampleApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ExampleApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ApiResult<ExampleVm>> GetById(string id)
        {
            var obj = new
            {
                id
            };

            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<ExampleVm>>("/api/Example/GetById", obj);
        }

        public async Task<ApiResult<PagedResult<ExampleVm>>> GetPagings(GetExamplePagingRequest request)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<PagedResult<ExampleVm>>>("/api/Example/GetPagings", request);
        }

        public async Task<ApiResult<string>> Create(CreateExampleVm model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<string>>("/api/Example/Create", model);
        }

        // Update ~ Create

        public async Task<ApiResult<string>> Delete(string id)
        {
            var dic = new Dictionary<string, string>()
            {
                { "id", id }
            };

            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsyncFormUrl<ApiResult<string>>("/api/Example/Delete", dic);
        }
    }
}
