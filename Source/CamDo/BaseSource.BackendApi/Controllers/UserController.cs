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
using BaseSource.ViewModels.User;
using BaseSource.Shared.Enums;

namespace BaseSource.BackendApi.Controllers
{
    public class UserController : BaseApiController
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
            
            var model = _db.Users.Where(x=> (x.Id == UserId  || x.UserProfile.SubUserId == UserId) && x.UserProfile.IsDelete !=true).AsQueryable();

            if (!string.IsNullOrEmpty(request.UserName))
            {
                model = model.Where(x => x.UserName.Contains(request.UserName));
            };

            if (!string.IsNullOrEmpty(request.Email))
            {
                model = model.Where(x => x.Email.Contains(request.Email));
            };

            var data = await model.Select(x => new UserShop()
            {
                Id = x.Id,
                UserName = x.UserName,
                Email = x.Email,
                Roles = (from ur in _db.UserRoles
                         join r in _db.Roles on ur.RoleId equals r.Id
                         where ur.UserId == x.Id
                         select r.Name).ToList(),
                JoinedDate = x.UserProfile.JoinedDate,
                LockoutEndDateUtc = x.LockoutEnd != null ? x.LockoutEnd.Value.DateTime : null
            }).OrderByDescending(x => x.JoinedDate).ToPagedListAsync(request.Page, request.PageSize);

            var pagedResult = new PagedResult<UserShop>()
            {
                TotalItemCount = data.TotalItemCount,
                PageSize = data.PageSize,
                PageNumber = data.PageNumber,
                Items = data.ToList()
            };

            return Ok(new ApiSuccessResult<PagedResult<UserShop>>(pagedResult));
        }

        [HttpGet("GetUserById/{id?}")]
        public async Task<IActionResult> GetById(string id)
        {
            var user = await _db.Users.FindAsync(id);
            if (user == null)
            {
                var resultnull = new UserShop();
                return Ok(new ApiSuccessResult<UserShop>(resultnull));
            }
            var roles = await _userManager.GetRolesAsync(user);
            var profile = await _db.UserProfiles.FindAsync(UserId);
            var cuahang = _db.UserProfiles.FirstOrDefault(x => x.UserId == user.Id);
            var result = new EditUserShop()
            {
                Id = user.Id.ToString(),
                Email = user.Email,
                FullName = profile?.FullName,
                UserName = user.UserName,
                JoinedDate = profile.JoinedDate,
                PhoneNumber = user.PhoneNumber,
                Roles = roles.ToList(),
                CuaHangId = cuahang.CuaHangId,
                Password = user.PasswordHash
            };

            return Ok(new ApiSuccessResult<EditUserShop>(result));
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
        [HttpPost("CreateOrUpdate")]
        public async Task<IActionResult> CreateOrUpdate(EditUserShop model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var user = await _db.Users.Include(x => x.UserProfile).Where(x => x.Id == model.Id).FirstOrDefaultAsync();
            if (user == null)
            {
                var newUser = new AppUser()
                {
                    UserName = model.UserName,
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    NormalizedEmail = model.Email
                };
                var result = await _userManager.CreateAsync(newUser, model.Password);
                if (result.Succeeded)
                {
                    await _db.UserProfiles.AddAsync(new UserProfile
                    {
                        CustomId = newUser.Id,
                        FullName = model.FullName,
                        JoinedDate = DateTime.Now,
                        UserId = newUser.Id,
                        CuaHangId = model.CuaHangId,
                        SubUserId = UserId,
                    });
                    var staff = (new Guid("ffded6b0-37d9-4676-241b-69459029a622")).ToString();
                    await _db.UserRoles.AddAsync(new IdentityUserRole<string> { UserId = newUser.Id, RoleId= staff });
                    await _db.SaveChangesAsync();
                    return Ok(new ApiSuccessResult<string>());
                }
                AddErrors(result, nameof(model.UserName));
            }
            else {
                user.Email = model.Email;
                user.NormalizedEmail = model.Email;
                user.PhoneNumber = model.PhoneNumber;
                user.UserProfile.FullName = model.FullName;
                if (!string.IsNullOrEmpty(model.Password))
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    await _userManager.ResetPasswordAsync(user, token, model.Password);
                }
                var userProfile = _db.UserProfiles.FirstOrDefault(x=> x.UserId == user.Id);
                if (userProfile != null)
                {
                    userProfile.FullName = model.FullName;
                    userProfile.CustomId = user.Id;
                    userProfile.CuaHangId = model.CuaHangId;
                    _db.Update(userProfile);
                    await _db.SaveChangesAsync();
                    return Ok(new ApiSuccessResult<string>());
                }
               
            }
            return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));
        }

        [HttpPost("DeleteUser")]
        public async Task<IActionResult> DeleteUser([FromForm] string userId)
        {
            var user = await _db.UserProfiles.FirstOrDefaultAsync(x=> x.UserId == userId && x.IsDelete == false);
            if (user != null)
            {
                user.IsDelete = true;
                _db.Update(user);
                await _db.SaveChangesAsync();
                return Ok(new ApiSuccessResult<string>("Xóa nhân viên thành công"));
            }
            return Ok(new ApiErrorResult<string>("User is not exits !"));
           

        }


        [HttpPost("LockUnLockUser")]
        public async Task<IActionResult> LockUnLockUser([FromForm] string id)
        {
            var user = await _db.Users.FindAsync(id);
            if (user == null)
            {
                return Ok(new ApiErrorResult<string>("Not Found"));
            }

            IdentityResult lockUserTask;
            IdentityResult lockDateTask;
            if (user.LockoutEnabled)
            {
                lockDateTask = await _userManager.SetLockoutEndDateAsync(user, DateTime.Now - TimeSpan.FromMinutes(1));
                lockUserTask = await _userManager.SetLockoutEnabledAsync(user, false);
            }
            else
            {
                lockUserTask = await _userManager.SetLockoutEnabledAsync(user, true);
                lockDateTask = await _userManager.SetLockoutEndDateAsync(user, DateTime.Now.AddYears(100));
            }
            if (lockUserTask.Succeeded && lockDateTask.Succeeded)
            {
                return Ok(new ApiSuccessResult<string>());
            }
            return Ok(new ApiErrorResult<string>());


        }
        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromForm] string id)
        {
            var user = await _db.Users.FindAsync(id);
            if (user == null)
            {
                return Ok(new ApiErrorResult<string>("Not found"));
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, "123456");
            if (result.Succeeded)
            {
                return Ok(new ApiSuccessResult<string>());
            }
            return Ok(new ApiErrorResult<string>("Có lỗi xảy ra. Vui lòng thử lại"));

        }

        [HttpGet("ThongBaoNoti")]
        public IActionResult ThongBaoNoti()
        {
            var Thongbao = new ThongBaoResponse()
            {
                AlarmDate = _db.HopDong_AlarmLogs.Count(x => x.UserId == UserId),
                Loan = _db.HopDongs.Count(x => x.HD_Loai == ELoaiHopDong.Vaylai && x.CuaHangId == CuaHangId),
                Pawn = _db.HopDongs.Count(x => x.HD_Loai == ELoaiHopDong.Camdo && x.CuaHangId == CuaHangId),
                Capital = _db.HopDongs.Count(x => x.HD_Loai == ELoaiHopDong.GopVon && x.CuaHangId == CuaHangId),
                Installment = _db.HopDongs.Count(x => x.HD_Loai == ELoaiHopDong.VayHo && x.CuaHangId == CuaHangId),
            };

            return Ok(new ApiSuccessResult<ThongBaoResponse>(Thongbao));
        }

        #region Helper
        private void AddErrors(IdentityResult result, string Property)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(Property, error.Description);
                break;
            }
        }
        #endregion
    }
}
