using BaseSource.Shared.Constants;
using BaseSource.Utilities.Helper;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.GoiSanPham;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ApiIntegration.WebApi.GoiSanPham
{
    public class GoiSanPhamApiClient : IGoiSanPhamApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public GoiSanPhamApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ApiResult<List<GoiSanPhamVm>>> GetAll()
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<List<GoiSanPhamVm>>>("/api/GoiSanPham/GetAll");
        }
    }
}
