using BaseSource.ViewModels.BaoCao;
using BaseSource.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ApiIntegration.WebApi.BaoCao
{
    public interface IBaoCaoApiClient
    {
        Task<ApiResult<ReportBalanceVM>> ReportBalance(ReportBalanceRequest request);
        Task<ApiResult<List<HD_PaymentLogReportVm>>> GetPaymentLog(ReportBalanceRequest request);
        Task<ApiResult<List<ReportPawnHoldingVm>>> ReportPawnHolding(ReportBalanceRequest request);
        Task<ApiResult<List<ReportPawnNewRepurchaseVM>>> ReportPawnNewRepurchase();
        Task<ApiResult<List<PaymentHistoryVM>>> PaymentHistory(ReportBalanceRequest request);
        Task<ApiResult<List<HD_PaymentLogReportVm>>> GetPaymentLog();
        Task<ApiResult<List<ReportPawnHoldingVm>>> ReportPawnHolding();
        Task<ApiResult<List<PaymentHistoryVM>>> PaymentHistory();
    }
}
