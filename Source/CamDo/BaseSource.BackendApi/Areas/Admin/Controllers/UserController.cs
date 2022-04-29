using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BaseSource.Data.EF;
using BaseSource.Data.Entities;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.Admin;
using X.PagedList;
using Microsoft.AspNetCore.Identity;

namespace BaseSource.BackendApi.Areas.Admin.Controllers
{
    public class UserController : BaseAdminApiController
    {
        private readonly BaseSourceDbContext _db;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public UserController(BaseSourceDbContext context,
                UserManager<AppUser> userManager,
                RoleManager<AppRole> roleManager)
        {
            _db = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }


        [HttpGet("GetPagings")]
        public async Task<IActionResult> GetPagings([FromQuery] GetUserPagingRequest_Admin request)
        {
            var model = _db.Users.AsQueryable();

            if (!string.IsNullOrEmpty(request.UserName))
            {
                model = model.Where(x => x.UserName.Contains(request.UserName));
            };

            if (!string.IsNullOrEmpty(request.Email))
            {
                model = model.Where(x => x.Email.Contains(request.Email));
            };

            var data = await model.Select(x => new UserVm()
            {
                Id = x.Id,
                UserName = x.UserName,
                Email = x.Email,
                Roles = (from ur in _db.UserRoles
                         join r in _db.Roles on ur.RoleId equals r.Id
                         where ur.UserId == x.Id
                         select r.Name).ToList(),
                JoinedDate = x.UserProfile.JoinedDate,
            }).OrderByDescending(x => x.JoinedDate).ToPagedListAsync(request.Page, request.PageSize);

            var pagedResult = new PagedResult<UserVm>()
            {
                TotalItemCount = data.TotalItemCount,
                PageSize = data.PageSize,
                PageNumber = data.PageNumber,
                Items = data.ToList()
            };

            return Ok(new ApiSuccessResult<PagedResult<UserVm>>(pagedResult));
        }

        [HttpGet("GetUserRoles")]
        public async Task<ActionResult> GetUserRoles(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return Ok(new ApiErrorResult<string>());
            }

            var userRoles = await _userManager.GetRolesAsync(user);
            var allRoles = await _roleManager.Roles.Select(x => x.Name).ToListAsync();

            var roleAssignRequest = new RoleAssignVm();
            roleAssignRequest.Id = id;
            foreach (var role in allRoles.OrderBy(x => x))
            {
                roleAssignRequest.Roles.Add(new SelectItem()
                {
                    Id = role,
                    Name = role,
                    Selected = userRoles.Contains(role)
                });
            }

            return Ok(new ApiSuccessResult<RoleAssignVm>(roleAssignRequest));
        }

        [HttpPost("RoleAssign")]
        public async Task<ActionResult> RoleAssign(RoleAssignVm model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.Id);
                if (user == null)
                {
                    return Ok(new ApiErrorResult<string>());
                }

                var userRoles = await _userManager.GetRolesAsync(user);
                await _userManager.RemoveFromRolesAsync(user, userRoles);

                var addedRoles = model.Roles.Where(x => x.Selected).Select(x => x.Name).ToList();
                if (model.Roles != null)
                {
                    await _userManager.AddToRolesAsync(user, addedRoles);
                }
                return Ok(new ApiSuccessResult<string>());
            }
            return Ok(new ApiErrorResult<string>());
        }


        //[HttpGet("GetById")]
        //public async Task<IActionResult> GetById(string id)
        //{
        //    var model = await _db.Notes.FindAsync(id);
        //    if (model == null)
        //    {
        //        return Ok(new ApiErrorResult<string>("Not found!"));
        //    }

        //    var data = new NoteQueryReponse_Admin()
        //    {
        //        Id = model.Id,
        //        NoteUrl = model.NoteUrl,
        //        DateUpdate = model.DateUpdate,
        //        TotalView = model.TotalView,
        //        Password = model.Password,
        //        ShareUrl = model.ShareUrl,
        //        DateCreate = model.DateCreate,
        //        Content = model.Content
        //    };

        //    return Ok(new ApiSuccessResult<NoteQueryReponse_Admin>(data));
        //}
    }
}
