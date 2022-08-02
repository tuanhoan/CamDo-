using BaseSource.ApiIntegration.WebApi.HopDong_ChuocDo;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.HopDong;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSource.WebApp.Areas.Admin.Controllers
{
    public class HopDong_ChuocDoController : BaseAdminController
    {
        private readonly IHopDong_ChuocDoApiClient _apiClient;
        public HopDong_ChuocDoController(IHopDong_ChuocDoApiClient apiClient)
        {
            _apiClient = apiClient;
        }
        public async Task<IActionResult> GetInfoChuocDo(int hopDongId, DateTime? ngayChuocDo)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var model = new HopDong_ChuocDoRequestVm()
            {
                HopDongId = hopDongId,
                NgayChuocDo = ngayChuocDo ?? DateTime.Now
            };
            var result = await _apiClient.GetInfoChuocDo(model);
            if (!result.IsSuccessed)
            {
                return NotFound();
            }

            return PartialView("_ChuocDo", result.ResultObj);
        }
        [HttpPost]
        public async Task<IActionResult> ChuocDo(HopDong_ChuocDoVm model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var result = await _apiClient.ChuocDo(model);
            if (!result.IsSuccessed)
            {
                return Json(new ApiErrorResult<string>(result.Message));
            }
            return Json(new ApiSuccessResult<string>(result.ResultObj));
        }
    }
}
