using BaseSource.ApiIntegration.WebApi.CuaHang;
using BaseSource.Data.EF;
using BaseSource.Data.Entities;
using BaseSource.Shared.Constants;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.CuaHang;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.WebApp.Areas.Admin.Controllers
{

    public class CuaHangController : BaseAdminController
    {
        private readonly ICuaHangApiClient _cuaHangApiClient;
        private readonly IConfiguration _configuration;
        public CuaHangController(ICuaHangApiClient cuaHangApiClient, IConfiguration configuration)
        {
            _cuaHangApiClient = cuaHangApiClient;
            _configuration = configuration;
        }
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
        public async Task<IActionResult> ChangeShop(int id)
        {
            var result = await _cuaHangApiClient.ChangeShop(id);
            var userPrincipal = this.ValidateToken(result.ResultObj);

            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(15),
                IsPersistent = false
            };
            HttpContext.Response.Cookies.Append(SystemConstants.AppSettings.Token, result.ResultObj, new CookieOptions { HttpOnly = true, Expires = DateTimeOffset.UtcNow.AddDays(15) });
            await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        userPrincipal, authProperties);
            return Json(new ApiSuccessResult<string>());
        }

        public async Task<IActionResult> GetShopByUser()
        {
            var result = await _cuaHangApiClient.GetShopByUser();
            return PartialView("_ListShop", result.ResultObj);
        }

        private ClaimsPrincipal ValidateToken(string jwtToken)
        {
            IdentityModelEventSource.ShowPII = true;

            SecurityToken validatedToken;
            TokenValidationParameters validationParameters = new TokenValidationParameters();

            validationParameters.ValidateLifetime = true;

            validationParameters.ValidAudience = _configuration["Tokens:Issuer"];
            validationParameters.ValidIssuer = _configuration["Tokens:Issuer"];
            validationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));

            ClaimsPrincipal principal = new JwtSecurityTokenHandler().ValidateToken(jwtToken, validationParameters, out validatedToken);

            return principal;
        }


        #region Shop details
        public async Task<IActionResult> DetailShop()
        {
            return View();
        }
        #endregion

        #region SumaryReportShop

        public async Task<IActionResult> SummaryReportShop()
        {
            return View();
        }
        #endregion

        #region MoneyNewDate
        public async Task<IActionResult> MoneyNewDate()
        {
            
            return View();
        }

        public async Task<IActionResult> CreateQuyDauNgay()
        {

            return View();
        }
        public async Task<IActionResult> CreateTienDauNgay()
        {

            return View();
        }
        public async Task<IActionResult> GetData()
        {
            

            return Json("");
        }
        #endregion
    }
}
