using BaseSource.ApiIntegration.WebApi.HopDong_DebtNote;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.HopDong_DebtNote;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSource.WebApp.Areas.Admin.Controllers
{
    public class HopDong_DebtNoteController : BaseAdminController
    {
        private readonly IHopDong_DebtNoteApiClient _apiClient;
        public HopDong_DebtNoteController(IHopDong_DebtNoteApiClient apiClient)
        {
            _apiClient = apiClient;
        }
        public async Task<IActionResult> GeHopDong_DebtNote(int hopdongId)
        {
            var result = await _apiClient.GetHopDong_DebtNote(hopdongId);
            return PartialView("_ListHopDong_DebtNote", result.ResultObj);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateHopDong_DebtNoteVm model)
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
            return Json(new ApiSuccessResult<string>(null, result.Message));
        }
    }
}
