using BaseSource.ApiIntegration.AdminApi.ReportCustomer;
using BaseSource.ViewModels.Admin;
using BaseSource.ViewModels.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSource.AdminApp.Controllers
{
    public class ReportCustomerController : Controller
    {
        private readonly IReportCustomerAdminApiClient _apiClient;
        public ReportCustomerController(IReportCustomerAdminApiClient apiClient)
        {
            _apiClient = apiClient;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            var request = new GetReportCustomerPagingRequest_Admin()
            {
                Page = page,
                PageSize = 10,
            };
            var result = await _apiClient.GetPagings(request);
            return View(result.ResultObj);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _apiClient.GetById(id);
            if (!result.IsSuccessed)
            {
                return NotFound();
            }
            var model = new EditReportCustomerAdminVm()
            {
                Id = result.ResultObj.Id,
                Address = result.ResultObj.Address,
                CMND = result.ResultObj.CMND,
                CustomerName = result.ResultObj.CustomerName,
                PhoneNumber = result.ResultObj.PhoneNumber,
                Reason = result.ResultObj.Reason
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditReportCustomerAdminVm model)
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
