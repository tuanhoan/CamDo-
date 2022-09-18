using BaseSource.ViewModels.BaoCao;
using BaseSource.ViewModels.BaoHiem;
using BaseSource.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ApiIntegration.WebApi.DichVu
{
    public interface IDichVuClient
    {
        Task<ApiResult<PagedResult<BaoHiemVm>>> GetPagings(BaohiemQr request);
    }
}
