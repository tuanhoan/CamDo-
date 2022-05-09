using BaseSource.ViewModels.Admin;
using BaseSource.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ApiIntegration.AdminApi.FeedBack
{
    public interface IFeedBackAdminApiClient
    {
        Task<ApiResult<PagedResult<FeedBackAdminVm>>> GetPagings(GetFeedBackPagingRequest_Admin model);
        Task<ApiResult<string>> Delete(int id);
    }
}
