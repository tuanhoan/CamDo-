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

        [AllowAnonymous]
        public IActionResult Register()
        {
            var model = new RegisterCuaHangVm();
            return View(model);
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
            return Json(new ApiSuccessResult<string>(Url.Action("Login", "Account")));
        }


    }
}
