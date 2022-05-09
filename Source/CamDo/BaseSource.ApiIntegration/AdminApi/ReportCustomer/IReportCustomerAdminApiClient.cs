using BaseSource.ViewModels.Admin;
using BaseSource.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ApiIntegration.AdminApi.ReportCustomer
{
    public interface IReportCustomerAdminApiClient
    {
        Task<ApiResult<PagedResult<ReportCustomerAdminVm>>> GetPagings(GetReportCustomerPagingRequest_Admin model);
        Task<ApiResult<string>> Edit(EditRportCustomerAdminVm model);
        Task<ApiResult<string>> Delete(int id);
    }
}
