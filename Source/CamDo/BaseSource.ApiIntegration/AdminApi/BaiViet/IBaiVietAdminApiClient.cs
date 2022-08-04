using BaseSource.ViewModels.Admin;
using BaseSource.ViewModels.Common;
using System.Threading.Tasks;

namespace BaseSource.ApiIntegration.AdminApi.BaiViet
{
    public interface IBaiVietAdminApiClient
    {
        Task<ApiResult<List<BaiVietAdminVm>>> GetPagings(GetBaiVietPagingRequest_Admin model);
        Task<ApiResult<string>> Create(CreateBaiVietAdminVm model);
        Task<ApiResult<BaiVietAdminVm>> GetById(int id);
        Task<ApiResult<string>> Edit(EditBaiVietAdminVm model);
        Task<ApiResult<string>> Delete(int id);
    }
}
