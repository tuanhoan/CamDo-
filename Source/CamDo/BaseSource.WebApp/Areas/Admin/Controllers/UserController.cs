
using BaseSource.ApiIntegration.AdminApi;
using BaseSource.Shared.Enums;
using BaseSource.ViewModels.Admin;
using BaseSource.ViewModels.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSource.WebApp.Areas.Admin.Controllers
{
    public class UserController : BaseAdminController
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
    }
}
