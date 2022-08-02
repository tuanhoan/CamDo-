using BaseSource.Shared.Constants;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.HopDong_VayRutGoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BaseSource.Utilities.Helper;

namespace BaseSource.ApiIntegration.WebApi.HopDong_VayRutGoc
{
    public class HopDong_VayRutGocApiClient : IHopDong_VayRutGocApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public HopDong_VayRutGocApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<ApiResult<List<HopDong_VayRutGocVm>>> GetByHopDong(int hopDongId)
        {
            var obj = new
            {
                hopDongId = hopDongId
            };
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<List<HopDong_VayRutGocVm>>>("/api/HopDong_VayRutGoc/GetByHopDong", obj);
        }
        public async Task<ApiResult<string>> TraBotGoc(TraBotGocRequestVm model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<string>>("/api/HopDong_VayRutGoc/TraBotGoc", model);
        }
        public async Task<ApiResult<string>> XoaTraBotGoc(int tranLogId)
        {
            var dic = new Dictionary<string, string>()
            {
                { "tranLogId", tranLogId.ToString() }
            };

            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsyncFormUrl<ApiResult<string>>("/api/HopDong_VayRutGoc/XoaTraBotGoc", dic);
        }
        public async Task<ApiResult<string>> VayThem(VayThemRequestVm model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<string>>("/api/HopDong_VayRutGoc/VayThem", model);
        }
    }
}
