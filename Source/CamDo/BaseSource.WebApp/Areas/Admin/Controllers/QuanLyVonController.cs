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
    public class QuanLyVonController : BaseAdminController
    {
         private readonly IHopDongApiClient _hopDongApiClient;
          private readonly IUserApiClient _userApiClient;
        public QuanLyVonController(IHopDongApiClient hopDongApiClient,IUserApiClient userApiClient)
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
                LoaiHopDong = ELoaiHopDong.GopVon,
                FormDate = from,
                ToDate = to,
                Info = info,
                Status = status
            };
            var result = _hopDongApiClient.GetPagings(request);
            await Task.WhenAll(result);
            return View(result.Result.ResultObj);
        }

        public async Task<IActionResult> Create()
        {
            var model = new CreateHopDongGopVonVm()
            {
                HD_NgayVay = DateTime.Now.Date
            };
            return PartialView("_Create", model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateHopDongGopVonVm model)
        {
            if (!ModelState.IsValid)
            {
                var tmp = ModelState.GetListErrors();
                return Json(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            model.HD_Ma = Guid.NewGuid().ToString();
            var result = await _hopDongApiClient.CreateHopDongGopVon(model);
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
            var model = new EditHopDongGopVonVm()
            {
                Id = result.ResultObj.Id,
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
                HangHoaId = result.ResultObj.HangHoaId,
                ListThuocTinhHangHoa = result.ResultObj.ListThuocTinhHangHoa,
                UserIdAssigned = result.ResultObj.UserIdAssigned,
            };

            return PartialView("_Edit", model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditHopDongGopVonVm model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var result = await _hopDongApiClient.EditHopDongGopVon(model);
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
    }
}
