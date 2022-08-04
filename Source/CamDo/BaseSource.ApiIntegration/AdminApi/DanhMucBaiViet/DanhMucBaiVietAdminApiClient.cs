using BaseSource.Shared.Constants;
using BaseSource.Utilities.Helper;
using BaseSource.ViewModels.Admin;
using BaseSource.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ApiIntegration.AdminApi.DanhMucBaiViet
{
    public class DanhMucBaiVietAdminApiClient : IDanhMucBaiVietAdminApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public DanhMucBaiVietAdminApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ApiResult<string>> Create(CreateDanhMucBaiVietAdminVm model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<string>>("/api/admin/DanhMucBaiViet/Create", model);
        }

        public async Task<ApiResult<string>> Delete(int id)
        {
            var dic = new Dictionary<string, string>()
            {
                { "id", id.ToString() }
            };

            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsyncFormUrl<ApiResult<string>>("/api/admin/DanhMucBaiViet/Delete", dic);
        }

        public async Task<ApiResult<string>> Edit(EditDanhMucBaiVietAdminVm model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<string>>("/api/admin/DanhMucBaiViet/Edit", model);
        }

        public async Task<ApiResult<ViewModels.Common.List<DanhMucBaiVietAdminVm>>> GetAll()
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<ViewModels.Common.List<DanhMucBaiVietAdminVm>>>("/api/admin/DanhMucBaiViet/GetAll");
        }

        public async Task<ApiResult<DanhMucBaiVietAdminVm>> GetById(int id)
        {
            var obj = new
            {
                id = id
            };
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<DanhMucBaiVietAdminVm>>("/api/admin/DanhMucBaiViet/GetById", obj);
        }

        public async Task<ApiResult<ViewModels.Common.List<DanhMucBaiVietAdminVm>>> GetPagings(GetDanhMucBaiVietPagingRequest_Admin model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<ViewModels.Common.List<DanhMucBaiVietAdminVm>>>("/api/admin/DanhMucBaiViet/GetPagings", model);
        }
    }
}
