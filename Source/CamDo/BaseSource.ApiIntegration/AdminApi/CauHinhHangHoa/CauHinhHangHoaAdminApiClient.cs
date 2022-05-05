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

namespace BaseSource.ApiIntegration.AdminApi.CauHinhHangHoa
{
    public class CauHinhHangHoaAdminApiClient : ICauHinhHangHoaAdminApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public CauHinhHangHoaAdminApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<ApiResult<string>> Create(CreateCauHinhHangHoaAdminVm model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<string>>("/api/admin/CauHinhHangHoa/Create", model);
        }

        public async Task<ApiResult<string>> Delete(int id)
        {
            var dic = new Dictionary<string, string>()
            {
                { "id", id.ToString() }
            };

            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsyncFormUrl<ApiResult<string>>("/api/admin/CauHinhHangHoa/Delete", dic);
        }

        public async Task<ApiResult<string>> Edit(EditCauHinhHangHoaAdminVm model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<string>>("/api/admin/CauHinhHangHoa/Edit", model);
        }

        public async Task<ApiResult<CauHinhHangHoaAdminVm>> GetById(int id)
        {
            var obj = new
            {
                id = id
            };
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<CauHinhHangHoaAdminVm>>("/api/admin/CauHinhHangHoa/GetById", obj);
        }

        public async Task<ApiResult<PagedResult<CauHinhHangHoaAdminVm>>> GetPagings(GetCauHinhHangHoaPagingRequest_Admin model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<PagedResult<CauHinhHangHoaAdminVm>>>("/api/admin/CauHinhHangHoa/GetPagings", model);
        }
    }
}
