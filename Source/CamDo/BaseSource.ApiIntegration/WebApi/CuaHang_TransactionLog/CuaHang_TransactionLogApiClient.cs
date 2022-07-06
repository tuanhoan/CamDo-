using BaseSource.Shared.Constants;
using BaseSource.Shared.Enums;
using BaseSource.Utilities.Helper;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.CuaHang_TransactionLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ApiIntegration.WebApi.CuaHang_TransactionLog
{
    public class CuaHang_TransactionLogApiClient : ICuaHang_TransactionLogApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public CuaHang_TransactionLogApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ApiResult<List<CuaHang_TransactionLogVm>>> GetCuaHang_TransactionLogHistory(int hopDongId, EHopDong_ActionType actionType = 0)
        {
            var obj = new
            {
                hopDongId = hopDongId,
                actionType = actionType
            };
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<List<CuaHang_TransactionLogVm>>>("/api/CuaHang_TransactionLog/GetCuaHang_TransactionLogHistory", obj);
        }
    }
}
