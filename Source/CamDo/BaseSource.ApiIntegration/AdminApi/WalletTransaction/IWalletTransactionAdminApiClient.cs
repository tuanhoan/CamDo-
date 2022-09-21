using BaseSource.ViewModels.Admin;
using BaseSource.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ApiIntegration.AdminApi.WalletTransaction
{
    public interface IWalletTransactionAdminApiClient
    {
        Task<ApiResult<PagedResult<WalletTransactionVM>>> GetPagings(WalletTransactionPagingRequest_Admin model);
        Task<ApiResult<string>> Create(WalletTransactionCreate model);
        Task<ApiResult<GoiSanPhamAdminVm>> GetById(int id);
        Task<ApiResult<string>> Edit(WalletTransactionEdit model);
        Task<ApiResult<string>> Delete(int id);


    }
}
