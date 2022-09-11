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
        public async Task<ApiResult<PagedResult<QuyCuaHangVm>>> GetPagings(PageQuery model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<PagedResult<QuyCuaHangVm>>>("/api/CuaHang_QuyTienLog/GetPagingQuyLogs", model);
        }
        public async Task<ApiResult<string>> CreateOrUpdate(CreateQuyCuaHang model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<string>>("/api/CuaHang_QuyTienLog/CreateOrUpdate", model);
        }
        public async Task<ApiResult<string>> DeleteQuyCH(int id)
        {
            var dic = new Dictionary<string, string>()
            {
                { "id", id.ToString() }
            };

            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsyncFormUrl<ApiResult<string>>("/api/CuaHang_QuyTienLog/Delete", dic);
        }

        public async Task<ApiResult<QuyCuaHangThongKeVm>> GetDataThongKe()
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<QuyCuaHangThongKeVm>>("/api/CuaHang_QuyTienLog/GetDataThongKe");
        }
        public async Task<ApiResult<DashboardDetail>> GetDashBoard(int CuaHangId)
        {
            var obj = new
            {
                CuaHangId = CuaHangId
            };
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<DashboardDetail>>("/api/CuaHang/GetDashBoardByChId", obj);
        }
    }
}
