using BaseSource.ViewModels.Admin;
using BaseSource.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BaseSource.Utilities.Helper;
using BaseSource.Shared.Constants;

namespace BaseSource.ApiIntegration.AdminApi.WalletTransaction
{
    public class GoiSanPham_LichSuMuaAdminApiClient : IGoiSanPham_LichSuMuaAdminApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public GoiSanPham_LichSuMuaAdminApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<ApiResult<string>> Create(GoiSanPham_LichSuMuaCreate model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<string>>("/api/admin/GoiSanPham_LichSuMua/Create", model);
        }

        public async Task<ApiResult<string>> Delete(int id)
        {
            var dic = new Dictionary<string, string>()
            {
                { "id", id.ToString() }
            };

            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsyncFormUrl<ApiResult<string>>("/api/admin/GoiSanPham_LichSuMua/Delete", dic);
        }

        public async Task<ApiResult<string>> Edit(GoiSanPham_LichSuMuaEdit model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<string>>("/api/admin/GoiSanPham_LichSuMua/Edit", model);
        }

        public async Task<ApiResult<GoiSanPham_LichSuMuaVM>> GetById(int id)
        {
            var obj = new
            {
                id = id
            };
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<GoiSanPham_LichSuMuaVM>>("/api/admin/GoiSanPham_LichSuMua/GetById", obj);
        }

        public async Task<ApiResult<PagedResult<GoiSanPham_LichSuMuaVM>>> GetPagings(GoiSanPham_LichSuMuaQr model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<PagedResult<GoiSanPham_LichSuMuaVM>>>("/api/admin/GoiSanPham_LichSuMua/GetPagings", model);
        }
    }
}
