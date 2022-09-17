using BaseSource.ViewModels.Admin;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.CuaHang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ApiIntegration.WebApi.CuaHang
{
    public interface ICuaHangApiClient
    {
        Task<ApiResult<PagedResult<CuaHangVm>>> GetPagings(GetCuaHangPagingRequest model);
        Task<ApiResult<string>> Create(CreateCuaHangVm model);
        Task<ApiResult<CuaHangVm>> GetById(int id);
        Task<ApiResult<string>> Edit(EditCuaHangVm model);
        Task<ApiResult<string>> Delete(int id);
        Task<ApiResult<string>> ChangeShop(int id);

        Task<ApiResult<string>> RegisterCuaHang(RegisterCuaHangVm model);

        Task<ApiResult<List<CuaHangVm>>> GetShopByUser();

        Task<ApiResult<PagedResult<QuyCuaHangVm>>> GetPagings(PageQuery model);
        Task<ApiResult<string>> CreateOrUpdate(CreateQuyCuaHang model);
        Task<ApiResult<string>> DeleteQuyCH(int id);
        Task<ApiResult<QuyCuaHangThongKeVm>> GetDataThongKe();
        Task<ApiResult<DashboardDetail>> GetDashBoard(int cuaHangId);
        Task<ApiResult<List<SummaryReportShopVM>>> SummaryReportShop();
        Task<ApiResult<DetailShopVM>> DetailShop();

    }
}