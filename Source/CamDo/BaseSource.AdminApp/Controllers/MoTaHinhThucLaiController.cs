using BaseSource.ApiIntegration.AdminApi.MoTaHinhThucLai;
using BaseSource.ViewModels.Admin;
using BaseSource.ViewModels.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSource.AdminApp.Controllers
{
    public class MoTaHinhThucLaiController : Controller
    {
        public readonly IMoTaHinhThucLaiAdmiApiClient _apiClient;
        public MoTaHinhThucLaiController(IMoTaHinhThucLaiAdmiApiClient apiClient)
        {
            _apiClient = apiClient;
        }
        public async Task<IActionResult> Index(string ten, int hinhthuclai, int page = 1)
        {
            var request = new GetMoTaHinhThucLaiPagingRequest_Admin()
            {
                Page = page,
                PageSize = 10,
                HinhThucLai = hinhthuclai
            };
            var result = await _apiClient.GetPagings(request);
            return View(result.ResultObj);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateMoTaHinhThucLaiAdminVm model)
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
            return Json(new ApiSuccessResult<string>(Url.Action("Index")));
        }
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _apiClient.GetById(id);
            if (!result.IsSuccessed)
            {
                return NotFound();
            }
            var model = new EditMoTaHinhThucLaiAdminVm()
            {
                Id = result.ResultObj.Id,
                HinhThucLai = result.ResultObj.HinhThucLai,
                MoTaKyLai = result.ResultObj.MoTaKyLai,
                TyLeLai = result.ResultObj.TyLeLai
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditMoTaHinhThucLaiAdminVm model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var result = await _apiClient.Edit(model);
            if (!result.IsSuccessed)
            {
                return Json(new ApiErrorResult<string>(result.ValidationErrors));
            }
            return Json(new ApiSuccessResult<string>(Url.Action("Index")));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _apiClient.Delete(id);
            if (result.IsSuccessed)
            {
                return Json(new ApiSuccessResult<string>());
            }
            return Json(new ApiErrorResult<string>(result.Message));
        }
    }
}
