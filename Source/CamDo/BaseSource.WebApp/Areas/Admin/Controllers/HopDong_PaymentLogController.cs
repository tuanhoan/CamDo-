using BaseSource.ApiIntegration.WebApi.HD_PaymentLog;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.HD_PaymentLog;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSource.WebApp.Areas.Admin.Controllers
{
    public class HopDong_PaymentLogController : BaseAdminController
    {
        private readonly IHopDong_PaymentLogApiClient _hdPaymentLogApiClient;
        public HopDong_PaymentLogController(IHopDong_PaymentLogApiClient hdPaymentLogApiClient)
        {
            _hdPaymentLogApiClient = hdPaymentLogApiClient;
        }
       
        public async Task<IActionResult> GetListPaymentLog(int hdId)
        {
            var result = await _hdPaymentLogApiClient.GetPaymentLogByHD(hdId);
            return PartialView("_HD_PaymentLog", result.ResultObj);
        }
        public async Task<IActionResult> GetInfoPaymentByDate(int hdId)
        {
            var result = await _hdPaymentLogApiClient.GetPaymentByDate(hdId);
            return PartialView("_DongLaiTheoNgay", result.ResultObj);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePayment(int paymentId, int hdId, double customerPay)
        {
            var model = new CreateHDPaymentLogVm()
            {
                PaymentID = paymentId,
                HDId = hdId,
                CustomerPay = customerPay
            };
            var result = await _hdPaymentLogApiClient.Create(model);
            if (!result.IsSuccessed)
            {
                return Json(new ApiErrorResult<string>(result.ValidationErrors));
            }
            return Json(new ApiSuccessResult<HD_PaymentLogReponse>(result.ResultObj, result.Message));
        }
        public async Task<IActionResult> DeletePayment(long paymentId)
        {
            var result = await _hdPaymentLogApiClient.Delete(paymentId);
            if (!result.IsSuccessed)
            {
                return Json(new ApiErrorResult<string>(result.Message));
            }
            return Json(new ApiSuccessResult<HD_PaymentLogReponse>(result.ResultObj, result.Message));
        }
        public async Task<IActionResult> ChangePaymentDate(int hdId, string dateChange)
        {
            var model = new ChangePaymentDateRequestVm()
            {
                HdId = hdId,
                DateChange = Convert.ToDateTime(dateChange)
            };
            var result = await _hdPaymentLogApiClient.ChangePaymentDate(model);
            if (!result.IsSuccessed)
            {
                return Json(new ApiErrorResult<string>(result.Message));
            }
            return Json(new ApiSuccessResult<ChangePaymentDateResponseVm>(result.ResultObj));
        }
        public async Task<IActionResult> CreateHDPaymentByDate(HDPaymentByDateVm model)
        {
            var result = await _hdPaymentLogApiClient.CreatePaymentByDate(model);
            if (!result.IsSuccessed)
            {
                return Json(new ApiErrorResult<string>(result.Message));
            }
            return Json(new ApiSuccessResult<HD_PaymentLogReponse>(result.ResultObj, result.Message));
        }
       
    }
}
