using BaseSource.Shared.Constants;
using BaseSource.ViewModels.Admin;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.MoTaHinhThucLai;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BaseSource.Utilities.Helper;

namespace BaseSource.ApiIntegration.WebApi.MoTaHinhThucLai
{
    public class MoTaHinhThucLaiApiClient : IMoTaHinhThucLaiApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public MoTaHinhThucLaiApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<ApiResult<PagedResult<MoTaHinhThucLaiVm>>> GetPagings(GetMoTaHinhThucLaiPagingRequest model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<PagedResult<MoTaHinhThucLaiVm>>>("/api/MoTaHinhThucLai/GetPagings", model);
        }
    }
}
