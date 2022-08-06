using BaseSource.Shared.Constants;
using BaseSource.Utilities.Helper;
using BaseSource.ViewModels.Admin;
using BaseSource.ViewModels.Admin.ThuChi;
using BaseSource.ViewModels.Common;
using System.Net.Http;
using System.Threading.Tasks;

namespace BaseSource.ApiIntegration.WebApi.QuanlyThuChi
{
    public class QuanLyThuChiApiClient : IQuanLyThuChiApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public QuanLyThuChiApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ApiResult<string>> CreateExpenseAsync(CreateChiHoatDongVm model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<string>>("/api/ThuChi/Expense", model);
        }

        public async Task<ApiResult<string>> CreateIncomeAsync(CreateThuHoatDongVm model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<string>>("/api/ThuChi/Income", model);
        }

        public async Task<ApiResult<string>> DeleteExpenseAsync(long id)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<string>>($"/api/ThuChi/Expense/{id}/delete");
        }

        public async Task<ApiResult<string>> DeleteInComeAsync(long id)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<string>>($"/api/ThuChi/income/{id}/delete");
        }

        public async Task<ApiResult<PagedResult<CuaHang_TransactionLogAdminVm>>> GetAllExpensesAsync(GetChiHoatDongPagingRequest model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<PagedResult<CuaHang_TransactionLogAdminVm>>>("/api/ThuChi/Expenses", model);
        }

        public async Task<ApiResult<PagedResult<CuaHang_TransactionLogAdminVm>>> GetAllIncomesAsync(GetThuHoatDongPagingRequest model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<PagedResult<CuaHang_TransactionLogAdminVm>>>("/api/ThuChi/Incomes", model);
        }
    }
}