using BaseSource.Shared.Constants;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.HopDong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BaseSource.Utilities.Helper;
using BaseSource.ViewModels.HD_PaymentLog;

namespace BaseSource.ApiIntegration.WebApi.HopDong
{
    public class HopDongApiClient : IHopDongApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public HopDongApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<ApiResult<string>> Create(CreateHopDongVm model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<string>>("/api/HopDong/Create", model);
        }
        public async Task<ApiResult<string>> Edit(EditHopDongVm model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<string>>("/api/HopDong/Edit", model);
        }

        public async Task<ApiResult<HopDongVm>> GetById(int id)
        {
            var obj = new
            {
                id = id
            };
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<HopDongVm>>("/api/HopDong/GetById", obj);
        }

        public async Task<ApiResult<PagedResult<HopDongVm>>> GetPagings(GetHopDongPagingRequest model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<PagedResult<HopDongVm>>>("/api/HopDong/GetPagings", model);
        }

        public async Task<ApiResult<string>> NoLai(HopDongNoLaiVm model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<string>>("/api/HopDong/NoLai", model);
        }

        public async Task<ApiResult<string>> TraNo(HopDongTraNoVm model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<string>>("/api/HopDong/TraNo", model);
        }
    }
}
