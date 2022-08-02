using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.GoiSanPham;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaseSource.ApiIntegration.WebApi.GoiSanPham
{
    public interface IGoiSanPhamApiClient
    {
        Task<ApiResult<List<GoiSanPhamVm>>> GetAll();
    }
}
