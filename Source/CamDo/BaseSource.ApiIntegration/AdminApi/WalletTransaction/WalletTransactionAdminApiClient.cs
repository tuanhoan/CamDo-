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
    public class WalletTransactionAdminApiClient : IWalletTransactionAdminApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public WalletTransactionAdminApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<ApiResult<string>> Create(CreateGoiSanPhamVm model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<string>>("/api/admin/WalletTransaction/Create", model);
        }

        public async Task<ApiResult<string>> Delete(int id)
        {
            var dic = new Dictionary<string, string>()
            {
                { "id", id.ToString() }
            };

            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsyncFormUrl<ApiResult<string>>("/api/admin/WalletTransaction/Delete", dic);
        }

        public async Task<ApiResult<string>> Edit(EditGoiSanPhamVm model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<string>>("/api/admin/WalletTransaction/Edit", model);
        }

        public async Task<ApiResult<GoiSanPhamAdminVm>> GetById(int id)
        {
            var obj = new
            {
                id = id
            };
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<GoiSanPhamAdminVm>>("/api/admin/WalletTransaction/GetById", obj);
        }

        public async Task<ApiResult<PagedResult<WalletTransactionVM>>> GetPagings(WalletTransactionPagingRequest_Admin model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<PagedResult<WalletTransactionVM>>>("/api/admin/WalletTransaction/GetPagings", model);
        }
    }
}
