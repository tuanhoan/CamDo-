using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.HopDong_GianHan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BaseSource.Utilities.Helper;
using BaseSource.Shared.Constants;
using BaseSource.ViewModels.HopDong;

namespace BaseSource.ApiIntegration.WebApi.HopDong_GianHan
{
    public class HopDong_GianHanApiClient : IHopDong_GianHanApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public HopDong_GianHanApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<ApiResult<List<HopDong_GiaHanVm>>> GetByHopDong(int hopDongId)
        {
            var obj = new
            {
                hopDongId = hopDongId
            };
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<List<HopDong_GiaHanVm>>>("/api/HopDong_GiaHan/GetByHopDong", obj);
        }

        public async Task<ApiResult<string>> GiaHan(GiaHanRequestVm model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<string>>("/api/HopDong_GiaHan/GiaHan", model);
        }
    }
}
