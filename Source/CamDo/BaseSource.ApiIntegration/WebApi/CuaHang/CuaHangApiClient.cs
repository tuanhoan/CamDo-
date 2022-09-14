using BaseSource.ViewModels.Admin;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.CuaHang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BaseSource.Utilities.Helper;
using BaseSource.Shared.Constants;

namespace BaseSource.ApiIntegration.WebApi.CuaHang
{
    public partial class CuaHangApiClient : ICuaHangApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public CuaHangApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ApiResult<string>> ChangeShop(int id)
        {
            var dic = new Dictionary<string, string>()
            {
                { "id", id.ToString() }
            };

            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsyncFormUrl<ApiResult<string>>("/api/CuaHang/ChangeShop", dic);
        }

        public async Task<ApiResult<string>> Create(CreateCuaHangVm model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<string>>("/api/CuaHang/Create", model);
        }

        public async Task<ApiResult<string>> Delete(int id)
        {
            var dic = new Dictionary<string, string>()
            {
                { "id", id.ToString() }
            };

            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsyncFormUrl<ApiResult<string>>("/api/CuaHang/Delete", dic);
        }

        public async Task<ApiResult<string>> Edit(EditCuaHangVm model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<string>>("/api/CuaHang/Edit", model);
        }

        public async Task<ApiResult<CuaHangVm>> GetById(int id)
        {
            var obj = new
            {
                id = id
            };
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<CuaHangVm>>("/api/CuaHang/GetById", obj);
        }

        public async Task<ApiResult<PagedResult<CuaHangVm>>> GetPagings(GetCuaHangPagingRequest model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<PagedResult<CuaHangVm>>>("/api/CuaHang/GetPagings", model);
        }

        public async Task<ApiResult<List<CuaHangVm>>> GetShopByUser()
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<List<CuaHangVm>>>("/api/CuaHang/GetShopByUser");
        }

        public async Task<ApiResult<string>> RegisterCuaHang(RegisterCuaHangVm model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<string>>("/api/CuaHang/Register", model);
        }

        public async Task<ApiResult<List<SummaryReportShopVM>>> SummaryReportShop()
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<List<SummaryReportShopVM>>>("/api/CuaHang/SummaryReportShop");
        }
    }
}
