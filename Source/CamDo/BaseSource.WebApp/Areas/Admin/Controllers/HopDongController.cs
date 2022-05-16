using AutoMapper;
using BaseSource.ApiIntegration.WebApi;
using BaseSource.ApiIntegration.WebApi.CauHinhHangHoa;
using BaseSource.ApiIntegration.WebApi.HopDong;
using BaseSource.ViewModels.CauHinhHangHoa;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.HopDong;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSource.WebApp.Areas.Admin.Controllers
{
    public class HopDongController : BaseAdminController
    {
        private readonly ICauHinhHangHoaApiClient _cauHinhHangHoaApiClient;
        private readonly IHopDongApiClient _hopDongApiClient;
        private readonly IUserApiClient _userApiClient;
        public HopDongController(ICauHinhHangHoaApiClient cauHinhHangHoaApiClient,
            IHopDongApiClient hopDongApiClient, IUserApiClient userApiClient)
        {
            _cauHinhHangHoaApiClient = cauHinhHangHoaApiClient;
            _hopDongApiClient = hopDongApiClient;
            _userApiClient = userApiClient;

        }
        public async Task<IActionResult> Create()
        {
            var requestCauHinhHH = new GetCauHinhHangHoaPagingRequest()
            {
                Page = 1,
                PageSize = int.MaxValue
            };
            var requestUser = _userApiClient.GetUserByCuaHang();
            var resultCuaHinhHH = _cauHinhHangHoaApiClient.GetPagings(requestCauHinhHH);

            await Task.WhenAll(requestUser, resultCuaHinhHH);

            ViewData["ListHangHoa"] = new SelectList(resultCuaHinhHH.Result.ResultObj.Items, "Id", "Ten");
            ViewData["ListUser"] = new SelectList(requestUser.Result.ResultObj, "UserName", "FullName");

            var model = new CreateHopDongVm()
            {
                HD_NgayVay = DateTime.Now.Date
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
            return Json(new ApiSuccessResult<string>());
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
                UserIdAssigned= result.ResultObj.UserIdAssigned,
            };
            var requestCauHinhHH = new GetCauHinhHangHoaPagingRequest()
            {
                Page = 1,
                PageSize = int.MaxValue
            };
            var requestUser = _userApiClient.GetUserByCuaHang();
            var resultCuaHinhHH = _cauHinhHangHoaApiClient.GetPagings(requestCauHinhHH);

            await Task.WhenAll(requestUser, resultCuaHinhHH);

            ViewData["ListHangHoa"] = new SelectList(resultCuaHinhHH.Result.ResultObj.Items, "Id", "Ten");
            ViewData["ListUser"] = new SelectList(requestUser.Result.ResultObj, "UserName", "FullName");
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



        public async Task<IActionResult> GetListThuocTinhByTaiSan(int id)
        {
            var result = await _cauHinhHangHoaApiClient.GetById(id);
            if (!result.IsSuccessed)
            {
                return NotFound();
            }
            var model = new List<ThuocTinhHangHoaVm>();
            if (!string.IsNullOrEmpty(result.ResultObj.ListThuocTinh))
            {
                var lstThuocTinh = JsonConvert.DeserializeObject<string[]>(result.ResultObj.ListThuocTinh);
                foreach (var item in lstThuocTinh)
                {
                    model.Add(new ThuocTinhHangHoaVm()
                    {
                        Name = item,
                        Value = "",
                    });
                }
            }
            return Json(model);
        }

    }
}
