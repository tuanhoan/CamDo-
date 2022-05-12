using BaseSource.ApiIntegration.WebApi.FeedBack;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.FeedBack;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSource.WebApp.Areas.Admin.Controllers
{
    public class FeedBackController : BaseAdminController
    {
        private readonly IFeedBackApiClient _apiClient;
        public FeedBackController(IFeedBackApiClient apiClient)
        {
            _apiClient = apiClient;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateFeedBackVm model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var result = await _apiClient.Create(model);
            if (!result.IsSuccessed)
            {
                return Json(new ApiErrorResult<string>(result.ValidationErrors));
            }
            return Json(new ApiSuccessResult<string>(result.ResultObj));

        }
    }
}
