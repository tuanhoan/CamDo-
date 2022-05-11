using BaseSource.ApiIntegration.AdminApi.NotifySystem;
using BaseSource.ViewModels.Admin;
using BaseSource.ViewModels.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSource.AdminApp.Controllers
{
    public class NotifySystemController : BaseController
    {
        private readonly INotifySystemAdminApiClient _apiClient;
        public NotifySystemController(INotifySystemAdminApiClient apiClient)
        {
            _apiClient = apiClient;
        }
        public async Task<IActionResult> Index(string ten, int page = 1)
        {
            var request = new GetNotifySystemPagingRequest_Admin()
            {
                Page = page,
                PageSize = 10,
                Info = ten
            };
            var result = await _apiClient.GetPagings(request);
            return View(result.ResultObj);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateNotifySystemVm model)
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
            var model = new EditNotifySystemVm()
            {
                Id = result.ResultObj.Id,
                Title = result.ResultObj.Title,
                Url = result.ResultObj.Url,
                StartTime = result.ResultObj.StartTime,
                EndTime = result.ResultObj.EndTime,
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditNotifySystemVm model)
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
