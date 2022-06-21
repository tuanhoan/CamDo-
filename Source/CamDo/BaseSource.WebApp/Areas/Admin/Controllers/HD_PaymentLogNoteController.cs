using BaseSource.ApiIntegration.WebApi.HD_PaymentLogNote;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.HD_PaymentLogNote;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSource.WebApp.Areas.Admin.Controllers
{
    public class HD_PaymentLogNoteController : BaseAdminController
    {
        private readonly IHD_PaymentLogNote _apiClient;
        public HD_PaymentLogNoteController(IHD_PaymentLogNote apiClient)
        {
            _apiClient = apiClient;
        }
        public async Task<IActionResult> GetNoteByPayment(long paymentId)
        {
            var result = await _apiClient.GetPaymentLogNoteByPayment(paymentId);
            return PartialView("_ListNoteByPayment", result.ResultObj);
        }
        public async Task<IActionResult> Create(CreatePaymentLogNoteVm model)
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
