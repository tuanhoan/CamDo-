using BaseSource.Shared.Constants;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.HD_PaymentLogNote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BaseSource.Utilities.Helper;

namespace BaseSource.ApiIntegration.WebApi.HD_PaymentLogNote
{
    public class HD_PaymentLogNote : IHD_PaymentLogNote
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public HD_PaymentLogNote(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<ApiResult<string>> Create(CreatePaymentLogNoteVm model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<string>>("/api/HD_PaymentLogNote/Create", model);
        }

        public async Task<ApiResult<List<HD_PaymentLogNoteVm>>> GetPaymentLogNoteByPayment(long paymentId)
        {
            var obj = new
            {
                paymentId = paymentId
            };
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<List<HD_PaymentLogNoteVm>>>("/api/HD_PaymentLogNote/GetPaymentLogNoteByPayment", obj);
        }
    }
}
