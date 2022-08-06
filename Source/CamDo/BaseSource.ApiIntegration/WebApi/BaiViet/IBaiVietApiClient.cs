using BaseSource.ViewModels.BaiViet;
using BaseSource.ViewModels.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaseSource.ApiIntegration.WebApi.BaiViet
{
    public interface IBaiVietApiClient
    {
        Task<ApiResult<List<BaiVietVm>>> GetAll();
        Task<ApiResult<BaiVietVm>> GetByUrl(string url);
    }
}
