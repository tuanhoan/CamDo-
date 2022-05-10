using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.FeedBack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ApiIntegration.WebApi.FeedBack
{
    public interface IFeedBackApiClient
    {
        Task<ApiResult<string>> Create(CreateFeedBackVm model);
    }
}
