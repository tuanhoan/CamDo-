using BaseSource.ViewModels.Admin;
using BaseSource.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ApiIntegration.AdminApi.WalletTransaction
{
    public interface IGoiSanPham_LichSuMuaAdminApiClient
    {
        Task<ApiResult<PagedResult<GoiSanPham_LichSuMuaVM>>> GetPagings(GoiSanPham_LichSuMuaQr model);
        Task<ApiResult<string>> Create(GoiSanPham_LichSuMuaCreate model);
        Task<ApiResult<GoiSanPham_LichSuMuaVM>> GetById(int id);
        Task<ApiResult<string>> Edit(GoiSanPham_LichSuMuaEdit model);
        Task<ApiResult<string>> Delete(int id);


    }
}
