using BaseSource.Shared.Constants;
using BaseSource.ViewModels.Admin;
using BaseSource.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BaseSource.Utilities.Helper;

namespace BaseSource.ApiIntegration.AdminApi.ReportCustomer
{
    public class ReportCustomerAdminApiClient : IReportCustomerAdminApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ReportCustomerAdminApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<ApiResult<string>> Delete(int id)
        {
            var dic = new Dictionary<string, string>()
            {
                { "id", id.ToString() }
            };

            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsyncFormUrl<ApiResult<string>>("/api/admin/ReportCustomer/Delete", dic);
        }

        public async Task<ApiResult<string>> Edit(EditReportCustomerAdminVm model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<string>>("/api/admin/ReportCustomer/Edit", model);
        }

        public async Task<ApiResult<ReportCustomerAdminVm>> GetById(int id)
        {
            var obj = new
            {
                id = id
            };
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<ReportCustomerAdminVm>>("/api/admin/ReportCustomer/GetById", obj);
        }

        public async Task<ApiResult<PagedResult<ReportCustomerAdminVm>>> GetPagings(GetReportCustomerPagingRequest_Admin model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<PagedResult<ReportCustomerAdminVm>>>("/api/admin/ReportCustomer/GetPagings", model);
        }

        
    }
}
