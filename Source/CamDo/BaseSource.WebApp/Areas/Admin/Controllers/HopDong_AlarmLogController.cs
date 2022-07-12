using BaseSource.ApiIntegration.WebApi.HopDong_AlarmLog;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.HopDong_AlarmLog;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSource.WebApp.Areas.Admin.Controllers
{
    public class HopDong_AlarmLogController : BaseAdminController
    {
        private readonly IHopDong_AlarmLog _apiClient;
        public HopDong_AlarmLogController(IHopDong_AlarmLog apiClient)
        {
            _apiClient = apiClient;
        }
        public async Task<IActionResult> GeHopDong_AlarmLog(int hopdongId)
        {
            var result = await _apiClient.GetHopDong_AlarmLog(hopdongId);
            return PartialView("_ListHopDong_AlarmLog", result.ResultObj);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateHopDong_AlarmLogVm model)
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
