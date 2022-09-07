using BaseSource.Shared.Constants;
using BaseSource.Utilities.Helper;
using BaseSource.ViewModels.BaoCao;
using BaseSource.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ApiIntegration.WebApi.BaoCao
{
    public class BaoCaoApiClient : IBaoCaoApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BaoCaoApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ApiResult<List<HD_PaymentLogReportVm>>> GetPaymentLog()
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<List<HD_PaymentLogReportVm>>>("/api/BaoCaos/GetPaymentLog");
        }

        public async Task<ApiResult<ReportBalanceVM>> ReportBalance(ReportBalanceRequest request)
        {
            var obj = new
            {
                formDate = request.FormDate,
                toDate = request.ToDate,
                userId = request.UserId,
                loaiHopDong = request.LoaiHopDong
            };
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<ReportBalanceVM>>("/api/BaoCaos/ReportBalance", request);
        }
    }
}
