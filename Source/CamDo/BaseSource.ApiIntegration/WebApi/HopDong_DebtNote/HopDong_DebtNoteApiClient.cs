using BaseSource.Shared.Constants;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.HopDong_DebtNote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BaseSource.Utilities.Helper;

namespace BaseSource.ApiIntegration.WebApi.HopDong_DebtNote
{
    public class HopDong_DebtNoteApiClient : IHopDong_DebtNoteApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public HopDong_DebtNoteApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<ApiResult<string>> Create(CreateHopDong_DebtNoteVm model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<string>>("/api/HopDong_DebtNote/Create", model);
        }

        public async Task<ApiResult<List<HopDong_DebtNoteVm>>> GetHopDong_DebtNote(int hopDongId)
        {
            var obj = new
            {
                hopDongId = hopDongId
            };
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<List<HopDong_DebtNoteVm>>>("/api/HopDong_DebtNote/GetHopDong_DebtNote", obj);
        }
    }
}
