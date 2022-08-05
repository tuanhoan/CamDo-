using BaseSource.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace BaseSource.ApiIntegration.AdminApi.Upload
{
    public interface IUploadAdminApiClient
    {
        Task<ApiResult<string>> UploadImage(IFormFile upload);
    }
}
