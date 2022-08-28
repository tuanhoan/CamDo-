using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.HopDong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BaseSource.Utilities.Helper;
using BaseSource.Shared.Constants;
using Newtonsoft.Json;

namespace BaseSource.ApiIntegration.WebApi.HopDong_ChuocDo
{
    public class HopDong_ChuocDoApiClient : IHopDong_ChuocDoApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public HopDong_ChuocDoApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ApiResult<string>> ChuocDo(HopDong_ChuocDoVm model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<string>>("/api/HopDong_ChuocDo/ChuocDo", model);
        }

        public async Task<ApiResult<HopDong_ChuocDoVm>> GetInfoChuocDo(HopDong_ChuocDoRequestVm model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            var newModel = new
            {
                HopDongId = model.HopDongId,
                NgayChuocDo = model.NgayChuocDo.ToString("yyyy-MM-dd"),
            };
            return await client.GetAsync<ApiResult<HopDong_ChuocDoVm>>("/api/HopDong_ChuocDo/GetInfoChuocDo", newModel);
        }
    }
}
