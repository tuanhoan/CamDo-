using BaseSource.ApiIntegration.WebApi;
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
    public class LoanController : BaseAdminController
    {
        private readonly IHopDongApiClient _hopDongApiClient;
        private readonly IUserApiClient _userApiClient;
        public LoanController(IHopDongApiClient hopDongApiClient, IUserApiClient userApiClient)
        {
            _hopDongApiClient = hopDongApiClient;
            _userApiClient = userApiClient;
        }
        public async Task<IActionResult> Index(string info, DateTime? from, DateTime? to, int? status, int page = 1)
        {
            var request = new GetHopDongPagingRequest()
            {
                Page = 1,
                PageSize = 10,
                LoaiHopDong = ELoaiHopDong.Vaylai,
                FormDate = from,
                ToDate = to,
                Info = info,
                Status = status
            };

            var result = await _hopDongApiClient.GetPagings(request);

            return View(result.ResultObj);
        }
        public async Task<IActionResult> ReportHeader()
        {
            var result = await _hopDongApiClient.GetReportHeader(ELoaiHopDong.Vaylai);
            return PartialView("_ReportHeader", result.ResultObj);
        }
        public async Task<IActionResult> Create()
        {
            var model = new CreateHopDongVayLaiVm()
            {
                HD_NgayVay = DateTime.Now.Date,
                HD_Loai = ELoaiHopDong.Vaylai
            };
            var requestUser = await _userApiClient.GetUserByCuaHang();
            ViewData["ListUser"] = new SelectList(requestUser.ResultObj, "Id", "FullName");

            return PartialView("_Create", model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateHopDongVayLaiVm model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var result = await _hopDongApiClient.CreateHopDongVayLai(model);
            if (!result.IsSuccessed)
            {
                return Json(new ApiErrorResult<string>(result.ValidationErrors));
            }
            return Json(new ApiSuccessResult<string>(result.ResultObj));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var result = await _hopDongApiClient.GetById(id);
            if (!result.IsSuccessed)
            {
                return NotFound();
            }
            var model = new EditHopDongVayLaiVm()
            {
                Id = result.ResultObj.Id,
                HD_Loai = result.ResultObj.HD_Loai,
                TenKhachHang = result.ResultObj.TenKhachHang,
                SDT = result.ResultObj.SDT,
                CMND = result.ResultObj.CMND,
                DiaChi = result.ResultObj.DiaChi,
                CMND_NoiCap = result.ResultObj.CMND_NoiCap,
                CMND_NgayCap = result.ResultObj.CMND_NgayCap,
                HD_Ma = result.ResultObj.HD_Ma,
                HD_LaiSuat = result.ResultObj.HD_LaiSuat,
                HD_NgayVay = result.ResultObj.HD_NgayVay,
                HD_TongThoiGianVay = result.ResultObj.HD_TongThoiGianVay,
                HD_TongTienVayBanDau = result.ResultObj.HD_TongTienVayBanDau,
                TenTaiSan = result.ResultObj.TenTaiSan,
                HD_HinhThucLai = result.ResultObj.HD_HinhThucLai,
                HD_GhiChu = result.ResultObj.HD_GhiChu,
                HD_IsThuLaiTruoc = result.ResultObj.HD_IsThuLaiTruoc,
                HD_KyLai = result.ResultObj.HD_KyLai,
                UserIdAssigned = result.ResultObj.UserIdAssigned,
            };

            var requestUser = _userApiClient.GetUserByCuaHang();
            ViewData["ListUser"] = new SelectList(requestUser.Result.ResultObj, "Id", "FullName");
            return PartialView("_Edit", model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditHopDongVm model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var result = await _hopDongApiClient.Edit(model);
            if (!result.IsSuccessed)
            {
                return Json(new ApiErrorResult<string>(result.ValidationErrors));
            }

            return Json(new ApiSuccessResult<string>(result.ResultObj));
        }

    }
}
