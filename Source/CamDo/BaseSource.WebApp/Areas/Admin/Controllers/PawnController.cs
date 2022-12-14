using BaseSource.ApiIntegration.WebApi.CauHinhHangHoa;
using BaseSource.ApiIntegration.WebApi.HopDong;
using BaseSource.Shared.Enums;
using BaseSource.ViewModels.CauHinhHangHoa;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.HopDong;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSource.WebApp.Areas.Admin.Controllers
{
    public class PawnController : BaseAdminController
    {
        private readonly IHopDongApiClient _hopDongApiClient;
        private readonly ICauHinhHangHoaApiClient _cauHinhHangHoaApiClient;
        public PawnController(IHopDongApiClient hopDongApiClient, ICauHinhHangHoaApiClient cauHinhHangHoaApiClient)
        {
            _hopDongApiClient = hopDongApiClient;
            _cauHinhHangHoaApiClient = cauHinhHangHoaApiClient;
        }
        public async Task<IActionResult> Index(string info, DateTime? from, DateTime? to, int? loaihanghoa, int? status, int page = 1)
        {
            var request = new GetHopDongPagingRequest()
            {
                Page = 1,
                PageSize = 10,
                LoaiHopDong = ELoaiHopDong.Camdo,
                FormDate = from,
                ToDate = to,
                Info = info,
                LoaiHangHoa = loaihanghoa,
                Status = status

            };
            var requestHH = new GetCauHinhHangHoaPagingRequest()
            {
                Page = 1,
                PageSize = int.MaxValue,
            };
            var result = _hopDongApiClient.GetPagings(request);
            var resultHH = _cauHinhHangHoaApiClient.GetPagings(requestHH);
            await Task.WhenAll(result, resultHH);
            ViewData["ListHangHoa"] = new SelectList(resultHH.Result.ResultObj.Items, "Id", "Ten");
            return View(result.Result.ResultObj);
        }
        public async Task<IActionResult> ReportHeader()
        {
            var result = await _hopDongApiClient.GetReportHeader(ELoaiHopDong.Camdo);
            return PartialView("_ReportHeader", result.ResultObj);
        }

        #region Chọn mẫu hợp đồng
        public async Task<IActionResult> ChonMauHopDong()
        {
            var result = await _hopDongApiClient.GetPrintDefault(ELoaiHopDong.Camdo);
            return PartialView("_ChonMauHopDong", result.ResultObj);
        }
        public async Task<IActionResult> SavePrintDefault(HopDongPrintDefaulVm model)
        {
            var result = await _hopDongApiClient.SavePrintDefault(model);
            return Ok(new ApiSuccessResult<string>("Lưu file default thành công"));
        }

        #endregion
    }
}
