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
    }
}
