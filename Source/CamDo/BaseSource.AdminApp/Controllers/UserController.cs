using BaseSource.ApiIntegration.AdminApi;
using BaseSource.ViewModels.Admin;
using BaseSource.ViewModels.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSource.AdminApp.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserAdminApiClient _apiClient;
        public UserController(IUserAdminApiClient apiClient)
        {
            _apiClient = apiClient;
        }
        public async Task<IActionResult> Index(string username, string email, int? page = 1)
        {
            var request = new GetUserPagingRequest_Admin()
            {
                Page = page.Value,
                PageSize = 20,
                UserName = username,
                Email = email
            };

            var result = await _apiClient.GetPagings(request);
            if (!result.IsSuccessed)
            {
                return NotFound();
            }

            return View(result.ResultObj);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserAdminVm model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var result = await _apiClient.Create(model);
            if (!result.IsSuccessed)
            {
                return Json(new ApiErrorResult<string>(result.ValidationErrors));
            }
            return Json(new ApiSuccessResult<string>(Url.Action("Index")));
        }
        public async Task<IActionResult> Edit(string id)
        {
            var result = await _apiClient.GetById(id);
            if (!result.IsSuccessed)
            {
                return NotFound();
            }
            var model = new EditUserAdminVm()
            {
                Id = result.ResultObj.Id,
                Email = result.ResultObj.Email,
                FullName = result.ResultObj.FullName,
                UserName = result.ResultObj.UserName,
                PhoneNumber = result.ResultObj.PhoneNumber,
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditUserAdminVm model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var result = await _apiClient.Edit(model);
            if (!result.IsSuccessed)
            {
                return Json(new ApiErrorResult<string>(result.ValidationErrors));
            }
            return Json(new ApiSuccessResult<string>(Url.Action("Index")));
        }
        public async Task<ActionResult> EditUserRole(string id)
        {
            var result = await _apiClient.GetUserRoles(id);
            if (!result.IsSuccessed)
            {
                return NotFound();
            }

            return PartialView("_EditUserRole", result.ResultObj);
        }

        [HttpPost]
        public async Task<ActionResult> EditUserRole(RoleAssignVm model)
        {
            if (!ModelState.IsValid)
            {
                return Json(false);
            }

            var result = await _apiClient.RoleAssign(model);
            if (!result.IsSuccessed)
            {
                return Json(false);
            }

            return Json(true);
        }

        [HttpPost]
        public async Task<ActionResult> LockUnLockUser(string id)
        {
            var result = await _apiClient.LockUnLockUser(id);
            if (!result.IsSuccessed)
            {
                return Json(new ApiErrorResult<string>());
            }

            return Json(new ApiSuccessResult<string>());
        }
    }
}
