
using BaseSource.ApiIntegration.AdminApi;
using BaseSource.ApiIntegration.WebApi;
using BaseSource.ApiIntegration.WebApi.CuaHang;
using BaseSource.Shared.Enums;
using BaseSource.ViewModels.Admin;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.CuaHang;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSource.WebApp.Areas.Admin.Controllers
{
    public class UserController : BaseAdminController
    {
        private readonly IUserApiClient _apiClientUser;
        private readonly ICuaHangApiClient _apiClientCuaHang;
        public UserController(IUserApiClient apiClient, ICuaHangApiClient apiClientCuaHang)
        {
            _apiClientUser = apiClient;
            _apiClientCuaHang = apiClientCuaHang;
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

            var result = await _apiClientUser.GetPagings(request);
            if (!result.IsSuccessed)
            {
                return NotFound();
            }

            return View(result.ResultObj);
        }
        //public async Task<ActionResult> EditUserRole(string id)
        //{
        //    var result = await _apiClient.GetUserRoles(id);
        //    if (!result.IsSuccessed)
        //    {
        //        return NotFound();
        //    }

        //    return PartialView("_EditUserRole", result.ResultObj);
        //}

        [HttpPost]
        public async Task<IActionResult> EditUserRole(RoleAssignVm model)
        {
            if (!ModelState.IsValid)
            {
                return Json(false);
            }

            //var result = await _apiClient.RoleAssign(model);
            //if (!result.IsSuccessed)
            //{
            //    return Json(false);
            //}

            return Json(true);
        }

        public async Task<IActionResult> CreateOrUpdateUser(string id = default)
        {
            var model = new EditUserShop();
            var mode = "Create";
            var result = await _apiClientUser.GetUserById(id);
            if (!result.IsSuccessed)
            {
                return NotFound();
            }
            if (result.ResultObj.Id != null)
            {
                model.Id = result.ResultObj.Id;
                model.Email = result.ResultObj.Email;
                model.FullName = result.ResultObj.FullName;
                model.UserName = result.ResultObj.UserName;
                model.PhoneNumber = result.ResultObj.PhoneNumber;
                mode = "Update";
            }
            var selectList = new List<SelectListItem>() { new SelectListItem { Text = "Vui lòng chọn cửa hàng ...", Value = "" } };
            var rsCuaHang = await  _apiClientCuaHang.GetShopByUser();
            if(rsCuaHang != null)
            {
                selectList.AddRange(rsCuaHang.ResultObj.Select(x => new SelectListItem() {Text = x.Ten , Value = x.Id.ToString() }).ToList());
            }

            ViewBag.CuaHangItems = selectList;
            ViewBag.Mode = mode;
            return PartialView("CreateOrUpdateUser", model);
        }
        public IActionResult _ModalCreateCuaHang()
        {  
            return PartialView("_ModalCreateCuaHang");
        }

        [HttpPost]
        public async Task<IActionResult> CreateCuaHang(CreateCuaHangVm model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var result = await _apiClientCuaHang.Create(model);
            if (!result.IsSuccessed)
            {
                return Json(new ApiErrorResult<string>(result.ValidationErrors));
            }
            return Json(new ApiSuccessResult<string>(Url.Action("CreateOrUpdateUser")));
        }
    }
}
