using BaseSource.ApiIntegration.WebApi.HopDong_VayRutGoc;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.HopDong;
using BaseSource.ViewModels.HopDong_VayRutGoc;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSource.WebApp.Areas.Admin.Controllers
{
    public class HopDong_VayRutGocController : BaseAdminController
    {
        private readonly IHopDong_VayRutGocApiClient _apiClient;
        public HopDong_VayRutGocController(IHopDong_VayRutGocApiClient apiClient)
        {
            _apiClient = apiClient;
        }
        public async Task<IActionResult> GetByHopDong(int hopDongId)
        {
            var result = await _apiClient.GetByHopDong(hopDongId);
            return PartialView("_ListHopDong_VayRutGoc", result.ResultObj);
        }
        #region Trả bớt gốc

        public async Task<IActionResult> TraBotGoc(TraBotGocRequestVm model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var result = await _apiClient.TraBotGoc(model);
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
        public async Task<IActionResult> XoaVayRutGoc(int tranLogId)
        {
            var result = await _apiClient.XoaVayRutGoc(tranLogId);
            if (!result.IsSuccessed)
            {
                return Json(new ApiErrorResult<string>(result.Message));
            }
            return Json(new ApiSuccessResult<string>(result.ResultObj, result.Message));
        }
        #endregion
        #region Vay thêm
        public async Task<IActionResult> VayThem(VayThemRequestVm model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var result = await _apiClient.VayThem(model);
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
        #endregion
    }
}
