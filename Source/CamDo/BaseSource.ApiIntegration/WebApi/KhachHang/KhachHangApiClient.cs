using BaseSource.Shared.Constants;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.KhachHang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BaseSource.Utilities.Helper;

namespace BaseSource.ApiIntegration.WebApi.KhachHang
{
    public class KhachHangApiClient : IKhachHangApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public KhachHangApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<ApiResult<List<KhachHangVm>>> GetByName(string info)
        {
            var obj = new
            {
                info = info
            };
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<List<KhachHangVm>>>("/api/KhachHang/GetByName", obj);
        }
    }
}
