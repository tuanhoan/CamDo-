using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.LienHe;
using System.Threading.Tasks;

namespace BaseSource.ApiIntegration.WebApi.LienHe
{
    public interface ILienHeApiClient
    {
        Task<ApiResult<string>> Create(CreateLienHeVm model);
    }
}
