using BaseSource.ViewModels.Catalog;
using BaseSource.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ApiIntegration.WebApi
{
    public interface IExampleApiClient
    {
        Task<ApiResult<ExampleVm>> GetById(string id);

        Task<ApiResult<PagedResult<ExampleVm>>> GetPagings(GetExamplePagingRequest request);

        Task<ApiResult<string>> Create(CreateExampleVm model);

        // Update ~ Create

        Task<ApiResult<string>> Delete(string id);
    }
}
