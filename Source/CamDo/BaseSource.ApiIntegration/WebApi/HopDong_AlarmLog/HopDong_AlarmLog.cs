using BaseSource.Shared.Constants;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.HopDong_AlarmLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BaseSource.Utilities.Helper;

namespace BaseSource.ApiIntegration.WebApi.HopDong_AlarmLog
{
    public class HopDong_AlarmLog : IHopDong_AlarmLog
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public HopDong_AlarmLog(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<ApiResult<string>> Create(CreateHopDong_AlarmLogVm model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<string>>("/api/HopDong_AlarmLog/Create", model);
        }

        public async Task<ApiResult<List<HopDong_AlarmLogVm>>> GetHopDong_AlarmLog(int hopDongId)
        {
            var obj = new
            {
                hopDongId = hopDongId
            };
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<List<HopDong_AlarmLogVm>>>("/api/HopDong_AlarmLog/GetHopDong_AlarmLog", obj);
        }
        public async Task<ApiResult<PagedResult<HopDong_AlarmLogVm>>> GetPagings(HopDong_AlarmLogRQ model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<PagedResult<HopDong_AlarmLogVm>>>("/api/HopDong_AlarmLog/GetPagings", model);
        }
    }
}
