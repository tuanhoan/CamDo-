using BaseSource.ViewModels.Admin;
using BaseSource.ViewModels.Admin.ThuChi;
using BaseSource.ViewModels.Common;

using System.Threading.Tasks;

namespace BaseSource.ApiIntegration.WebApi.QuanlyThuChi
{
    public interface IQuanLyThuChiApiClient
    {

        #region Thu
        Task<ApiResult<PagedResult<CuaHang_TransactionLogAdminVm>>> GetAllIncomesAsync(GetThuHoatDongPagingRequest model);
        Task<ApiResult<string>> CreateIncomeAsync(CreateThuHoatDongVm model);
        Task<ApiResult<string>> DeleteInComeAsync(long id);
        #endregion
        #region Chi
        Task<ApiResult<PagedResult<CuaHang_TransactionLogAdminVm>>> GetAllExpensesAsync(GetChiHoatDongPagingRequest model);
        Task<ApiResult<string>> CreateExpenseAsync(CreateChiHoatDongVm model);
        Task<ApiResult<string>> DeleteExpenseAsync(long id);
        #endregion
    }
}
