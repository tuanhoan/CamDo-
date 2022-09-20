using BaseSource.Shared.Constants;
using BaseSource.Utilities.Helper;
using BaseSource.ViewModels.BaoCao;
using BaseSource.ViewModels.BaoHiem;
using BaseSource.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ApiIntegration.WebApi.DichVu
{
    public class DichVuClient : IDichVuClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public DichVuClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ApiResult<string>> Create(BaoHiemCreate request)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<string>>("/api/BaoHiem/Create", request);
        }

        public async Task<ApiResult<PagedResult<BaoHiemVm>>> GetPagings(BaohiemQr request)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<PagedResult<BaoHiemVm>>>("/api/BaoHiem/GetPagings", request);
        }
    }
}
