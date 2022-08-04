using BaseSource.ViewModels.Admin;
using BaseSource.ViewModels.Common;
using System.Threading.Tasks;

namespace BaseSource.ApiIntegration.AdminApi.DanhMucBaiViet
{
    public interface IDanhMucBaiVietAdminApiClient
    {
        Task<ApiResult<List<DanhMucBaiVietAdminVm>>> GetAll();
        Task<ApiResult<List<DanhMucBaiVietAdminVm>>> GetPagings(GetDanhMucBaiVietPagingRequest_Admin model);
        Task<ApiResult<string>> Create(CreateDanhMucBaiVietAdminVm model);
        Task<ApiResult<DanhMucBaiVietAdminVm>> GetById(int id);
        Task<ApiResult<string>> Edit(EditDanhMucBaiVietAdminVm model);
        Task<ApiResult<string>> Delete(int id);
    }
}
