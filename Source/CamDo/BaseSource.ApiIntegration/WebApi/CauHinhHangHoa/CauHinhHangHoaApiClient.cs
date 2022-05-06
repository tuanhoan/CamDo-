using BaseSource.Shared.Constants;
using BaseSource.ViewModels.CauHinhHangHoa;
using BaseSource.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BaseSource.Utilities.Helper;

namespace BaseSource.ApiIntegration.WebApi.CauHinhHangHoa
{
    public class CauHinhHangHoaApiClient : ICauHinhHangHoaApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public CauHinhHangHoaApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<ApiResult<string>> Create(CreateCauHinhHangHoaVm model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<string>>("/api/CauHinhHangHoa/Create", model);
        }

        public async Task<ApiResult<string>> Delete(int id)
        {
            var dic = new Dictionary<string, string>()
            {
                { "id", id.ToString() }
            };

            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsyncFormUrl<ApiResult<string>>("/api/CauHinhHangHoa/Delete", dic);
        }

        public async Task<ApiResult<string>> Edit(EditCauHinhHangHoaVm model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<string>>("/api/CauHinhHangHoa/Edit", model);
        }

        public async Task<ApiResult<CauHinhHangHoaVm>> GetById(int id)
        {
            var obj = new
            {
                id = id
            };
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<CauHinhHangHoaVm>>("/api/CauHinhHangHoa/GetById", obj);
        }

        public async Task<ApiResult<PagedResult<CauHinhHangHoaVm>>> GetPagings(GetCauHinhHangHoaPagingRequest model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<PagedResult<CauHinhHangHoaVm>>>("/api/CauHinhHangHoa/GetPagings", model);
        }
    }
}
