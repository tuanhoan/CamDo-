using BaseSource.ApiIntegration.WebApi.HopDong_GianHan;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.HopDong_GianHan;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSource.WebApp.Areas.Admin.Controllers
{
    public class HopDong_GiaHanController : BaseAdminController
    {
        private readonly IHopDong_GianHanApiClient _apiClient;
        public HopDong_GiaHanController(IHopDong_GianHanApiClient apiClient)
        {
            _apiClient = apiClient;
        }
        public async Task<IActionResult> GetByHopDong(int hopDongId)
        {
            var result = await _apiClient.GetByHopDong(hopDongId);
            return PartialView("_ListHopDong_GiaHan", result.ResultObj);
        }
        public async Task<IActionResult> GiaHan(GiaHanRequestVm model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var result = await _apiClient.GiaHan(model);
            if (!result.IsSuccessed)
            {
                if (result.ValidationErrors != null && result.ValidationErrors.Count > 0)
                {
                    return Json(new ApiErrorResult<string>(result.ValidationErrors));
                }
                else if (result.Message != null)
                {
                    return Json(new ApiErrorResult<string>(result.Message));
                }

            }
            return Json(new ApiSuccessResult<string>(result.ResultObj, result.Message));
        }
    }
}
