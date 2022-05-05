using BaseSource.ViewModels.Admin;
using BaseSource.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ApiIntegration.AdminApi.CauHinhHangHoa
{
    public interface ICauHinhHangHoaAdminApiClient
    {
        Task<ApiResult<PagedResult<CauHinhHangHoaAdminVm>>> GetPagings(GetCauHinhHangHoaPagingRequest_Admin model);
        Task<ApiResult<string>> Create(CreateCauHinhHangHoaAdminVm model);
        Task<ApiResult<CauHinhHangHoaAdminVm>> GetById(int id);
        Task<ApiResult<string>> Edit(EditCauHinhHangHoaAdminVm model);
        Task<ApiResult<string>> Delete(int id);
    }
}
