using BaseSource.ApiIntegration.WebApi;
using BaseSource.ApiIntegration.WebApi.CauHinhHangHoa;
using BaseSource.ApiIntegration.WebApi.HopDong;
using BaseSource.ApiIntegration.WebApi.MoTaHinhThucLai;
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
        private readonly ICauHinhHangHoaApiClient _cauHinhHangHoaApiClient;
        private readonly IMoTaHinhThucLaiApiClient _moTaHinhThucLaiApiClient;
        public LoanController(IHopDongApiClient hopDongApiClient, IUserApiClient userApiClient,
            ICauHinhHangHoaApiClient cauHinhHangHoaApiClient, IMoTaHinhThucLaiApiClient moTaHinhThucLaiApiClient)
        {
            _hopDongApiClient = hopDongApiClient;
            _userApiClient = userApiClient;
            _cauHinhHangHoaApiClient = cauHinhHangHoaApiClient;
            _moTaHinhThucLaiApiClient = moTaHinhThucLaiApiClient;
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
            var result = await _hopDongApiClient.GetReportHeader(ELoaiHopDong.Vaylai);
            return PartialView("_ReportHeader", result.ResultObj);
        }
        public async Task<IActionResult> Create()
        {
            var requestCauHinhHH = new GetCauHinhHangHoaPagingRequest()
            {
                Page = 1,
                PageSize = int.MaxValue,
                LinhVuc = ELinhVucHangHoa.Vaylai
            };
            var requestUser = _userApiClient.GetUserByCuaHang();
            var resultCuaHinhHH = _cauHinhHangHoaApiClient.GetPagings(requestCauHinhHH);
            var maxIDHD = _hopDongApiClient.GetMaxID(ELoaiHopDong.Vaylai);
            await Task.WhenAll(requestUser, resultCuaHinhHH, maxIDHD);
            var hinhThucLai = await _moTaHinhThucLaiApiClient.GetAll();

            ViewData["ListHangHoa"] = new SelectList(resultCuaHinhHH.Result.ResultObj.Items, "Id", "Ten");
            ViewData["ListUser"] = new SelectList(requestUser.Result.ResultObj, "Id", "FullName");
            ViewData["HinhThucLai"] = new SelectList(hinhThucLai, "HinhThucLai", "Id");
            var model = new CreateHopDongVm()
            {
                HD_NgayVay = DateTime.Now.Date,
                HD_Loai = ELoaiHopDong.Vaylai,
                HD_MaTemp = maxIDHD.Result.ResultObj
            };
            return PartialView("_Create", model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateHopDongVm model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var result = await _hopDongApiClient.Create(model);
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
            var model = new EditHopDongVm()
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
                HD_MaTemp = result.ResultObj.HD_MaTemp,
            };

            var requestCauHinhHH = new GetCauHinhHangHoaPagingRequest()
            {
                Page = 1,
                PageSize = int.MaxValue,
                LinhVuc = ELinhVucHangHoa.Vaylai
            };
            var requestUser = _userApiClient.GetUserByCuaHang();
            var resultCuaHinhHH = _cauHinhHangHoaApiClient.GetPagings(requestCauHinhHH);

            await Task.WhenAll(requestUser, resultCuaHinhHH);

            ViewData["ListHangHoa"] = new SelectList(resultCuaHinhHH.Result.ResultObj.Items, "Id", "Ten");
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
        public async Task<IActionResult> Detail(int id, string tabActive)
        {
            var hd = await _hopDongApiClient.GetById(id);
            ViewData["TabActive"] = tabActive;
            return PartialView("_Detail", hd.ResultObj);
        }
        #region Chọn mẫu hợp đồng
        public async Task<IActionResult> ChonMauHopDong()
        {
            var result = await _hopDongApiClient.GetPrintDefault(ELoaiHopDong.Vaylai);
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
