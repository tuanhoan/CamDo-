using BaseSource.ViewModels.CauHinhHangHoa;
using BaseSource.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ApiIntegration.WebApi.CauHinhHangHoa
{
    public interface ICauHinhHangHoaApiClient
    {
        Task<ApiResult<PagedResult<CauHinhHangHoaVm>>> GetPagings(GetCauHinhHangHoaPagingRequest model);
        Task<ApiResult<string>> Create(CreateCauHinhHangHoaVm model);
        Task<ApiResult<CauHinhHangHoaVm>> GetById(int id, int hdId = 0);
        Task<ApiResult<string>> Edit(EditCauHinhHangHoaVm model);
        Task<ApiResult<string>> Delete(int id);
    }
}
