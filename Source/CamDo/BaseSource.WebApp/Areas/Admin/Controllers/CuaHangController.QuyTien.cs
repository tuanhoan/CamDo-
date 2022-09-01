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

    public partial class CuaHangController : BaseAdminController
    {
        
        #region MoneyNewDate
        public async Task<IActionResult> MoneyNewDate()
        {
            
            return View();
        }

        public async Task<IActionResult> CreateQuyDauNgay(CreateQuyCuaHang model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var result = await _cuaHangApiClient.CreateOrUpdate(model);
            if (!result.IsSuccessed)
            {
                return Json(new ApiErrorResult<string>(result.ValidationErrors));
            }
            return Json(new ApiSuccessResult<string>(Url.Action("Index")));
        }
        public async Task<IActionResult> CreateTienDauNgay(CreateQuyCuaHang model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var result = await _cuaHangApiClient.CreateOrUpdate(model);
            if (!result.IsSuccessed)
            {
                return Json(new ApiErrorResult<string>(result.ValidationErrors));
            }
            return Json(new ApiSuccessResult<string>(Url.Action("MoneyNewDate")));
        }
        public async Task<IActionResult> GetData(int page = 1)
        {
            var request = new PageQuery()
            {
                Page = page,
                PageSize = 10,
            };
            var result = await _cuaHangApiClient.GetPagings(request);
            return PartialView("_HistoryQuytien", result);
        }
        #endregion
    }
}
