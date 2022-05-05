using BaseSource.ApiIntegration.WebApi.CuaHang;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.CuaHang;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSource.WebApp.Controllers
{
    public class CuaHangController : BaseController
    {
        private readonly ICuaHangApiClient _cuaHangApiClient;
        public CuaHangController(ICuaHangApiClient cuaHangApiClient)
        {
            _cuaHangApiClient = cuaHangApiClient;
        }
        #region đăng ký cửa hàng
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterCuaHangVm model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var result = await _cuaHangApiClient.RegisterCuaHang(model);
            if (!result.IsSuccessed)
            {
                return Json(new ApiErrorResult<string>(result.ValidationErrors));
            }
            return Json(new ApiErrorResult<string>(Url.Action("Login", "Account")));
        }
        #endregion
        #region Quản lý cửa hàng
        public async Task<IActionResult> Index(string ten, string status, int page = 1)
        {
            var request = new GetCuaHangPagingRequest()
            {
                Page = page,
                PageSize = 10,
                Ten = ten,
                Status = status
            };
            var result = await _cuaHangApiClient.GetPagings(request);
            return View(result.ResultObj);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCuaHangVm model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var result = await _cuaHangApiClient.Create(model);
            if (!result.IsSuccessed)
            {
                return Json(new ApiErrorResult<string>(result.ValidationErrors));
            }
            return Json(new ApiSuccessResult<string>(Url.Action("Index")));
        }
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _cuaHangApiClient.GetById(id);
            if (!result.IsSuccessed)
            {
                return NotFound();
            }
            var model = new EditCuaHangVm()
            {
                Id = result.ResultObj.Id,
                DiaChi = result.ResultObj.DiaChi,
                SDT = result.ResultObj.SDT,
                TenCuaHang = result.ResultObj.Ten,
                TenNguoiDaiDien = result.ResultObj.TenNguoiDaiDien,
                VonDauTu = result.ResultObj.VonDauTu,
                IsActive = result.ResultObj.IsActive
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditCuaHangVm model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var result = await _cuaHangApiClient.Edit(model);
            if (!result.IsSuccessed)
            {
                return Json(new ApiErrorResult<string>(result.ValidationErrors));
            }
            return Json(new ApiSuccessResult<string>(Url.Action("Index")));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _cuaHangApiClient.Delete(id);
            if (result.IsSuccessed)
            {
                return Json(new ApiSuccessResult<string>());
            }
            return Json(new ApiErrorResult<string>(result.Message));
        }
        #endregion
    }
}
