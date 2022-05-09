using BaseSource.ApiIntegration.WebApi;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.User;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSource.WebApp.Areas.Admin.Controllers
{
    public class AccountController : BaseAdminController
    {
        private readonly IUserApiClient _userApiClient;
        public AccountController(IUserApiClient userApiClient)
        {
            _userApiClient = userApiClient;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ChangePassword()
        {
            return PartialView("_ChangePassword");
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordVm model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var result = await _userApiClient.ChangePassword(model);
            if (!result.IsSuccessed)
            {
                return Json(new ApiErrorResult<string>(result.ValidationErrors));
            }
            return Json(new ApiSuccessResult<string>(result.ResultObj));
        }
        public async Task<IActionResult> EditProfile()
        {
            var model = new EditProfileVm();
            var result = await _userApiClient.GetUserInfo();
            if (result.IsSuccessed)
            {
                model.FullName = result.ResultObj.FullName;
                model.Email = result.ResultObj.Email;
                model.PhoneNumber = result.ResultObj.PhoneNumber;
            }
            return PartialView("_EditProfile", model);
        }
        [HttpPost]
        public async Task<IActionResult> EditProfile(EditProfileVm model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var result = await _userApiClient.EditProfile(model);
            if (!result.IsSuccessed)
            {
                return Json(new ApiErrorResult<string>(result.ValidationErrors));
            }
            return Json(new ApiSuccessResult<string>(result.ResultObj));
        }
    }
}
