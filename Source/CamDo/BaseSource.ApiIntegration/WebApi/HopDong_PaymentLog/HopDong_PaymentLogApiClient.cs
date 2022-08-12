using BaseSource.Shared.Constants;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.HD_PaymentLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BaseSource.Utilities.Helper;

namespace BaseSource.ApiIntegration.WebApi.HD_PaymentLog
{
    public class HopDong_PaymentLogApiClient : IHopDong_PaymentLogApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public HopDong_PaymentLogApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<ApiResult<HD_PaymentLogVm>> GetPaymentLogByHD(int hdId)
        {
            var obj = new
            {
                hdId = hdId
            };
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<HD_PaymentLogVm>>("/api/HD_PaymentLog/GetPaymentLogByHD", obj);
        }
        public async Task<ApiResult<HD_PaymentLogReponse>> Create(CreateHDPaymentLogVm model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<HD_PaymentLogReponse>>("/api/HD_PaymentLog/Create", model);
        }
        public async Task<ApiResult<HD_PaymentLogReponse>> Delete(long id)
        {
            var dic = new Dictionary<string, string>()
            {
                { "id", id.ToString() }
            };

            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsyncFormUrl<ApiResult<HD_PaymentLogReponse>>("/api/HD_PaymentLog/Delete", dic);
        }

        public async Task<ApiResult<ChangePaymentDateResponseVm>> ChangePaymentDate(ChangePaymentDateRequestVm model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<ChangePaymentDateResponseVm>>("/api/HD_PaymentLog/ChangePaymentDate", model);
        }

        public async Task<ApiResult<HD_PaymentLogReponse>> CreatePaymentByDate(HDPaymentByDateVm model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<HD_PaymentLogReponse>>("/api/HD_PaymentLog/CreatePaymentByDate", model);
        }

        public async Task<ApiResult<HDPaymentByDateVm>> GetPaymentByDate(int hdId)
        {
            var obj = new
            {
                hdId = hdId
            };
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<HDPaymentByDateVm>>("/api/HD_PaymentLog/GetPaymentByDate", obj);
        }
    }
}
