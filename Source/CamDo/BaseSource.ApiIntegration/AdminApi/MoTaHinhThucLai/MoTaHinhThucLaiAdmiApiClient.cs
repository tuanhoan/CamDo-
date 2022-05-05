using BaseSource.Shared.Constants;
using BaseSource.ViewModels.Admin;
using BaseSource.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BaseSource.Utilities.Helper;

namespace BaseSource.ApiIntegration.AdminApi.MoTaHinhThucLai
{
    public class MoTaHinhThucLaiAdmiApiClient : IMoTaHinhThucLaiAdmiApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public MoTaHinhThucLaiAdmiApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<ApiResult<string>> Create(CreateMoTaHinhThucLaiAdminVm model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<string>>("/api/admin/MoTaHinhThucLai/Create", model);
        }

        public async Task<ApiResult<string>> Delete(int id)
        {
            var dic = new Dictionary<string, string>()
            {
                { "id", id.ToString() }
            };

            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsyncFormUrl<ApiResult<string>>("/api/admin/MoTaHinhThucLai/Delete", dic);
        }

        public async Task<ApiResult<string>> Edit(EditMoTaHinhThucLaiAdminVm model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<string>>("/api/admin/MoTaHinhThucLai/Edit", model);
        }

        public async Task<ApiResult<MoTaHinhThucLaiAdminVm>> GetById(int id)
        {
            var obj = new
            {
                id = id
            };
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<MoTaHinhThucLaiAdminVm>>("/api/admin/MoTaHinhThucLai/GetById", obj);
        }

        public async Task<ApiResult<PagedResult<MoTaHinhThucLaiAdminVm>>> GetPagings(GetMoTaHinhThucLaiPagingRequest_Admin model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<PagedResult<MoTaHinhThucLaiAdminVm>>>("/api/admin/MoTaHinhThucLai/GetPagings", model);
        }
    }
}
