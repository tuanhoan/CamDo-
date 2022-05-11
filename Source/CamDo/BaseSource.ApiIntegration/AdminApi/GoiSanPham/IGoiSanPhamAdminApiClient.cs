using BaseSource.ViewModels.Admin;
using BaseSource.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ApiIntegration.AdminApi.GoiSanPham
{
    public interface IGoiSanPhamAdminApiClient
    {
        Task<ApiResult<PagedResult<GoiSanPhamAdminVm>>> GetPagings(GetGoiSanPhamPagingRequest_Admin model);
        Task<ApiResult<string>> Create(CreateGoiSanPhamVm model);
        Task<ApiResult<GoiSanPhamAdminVm>> GetById(int id);
        Task<ApiResult<string>> Edit(EditGoiSanPhamVm model);
        Task<ApiResult<string>> Delete(int id);
    }
}
