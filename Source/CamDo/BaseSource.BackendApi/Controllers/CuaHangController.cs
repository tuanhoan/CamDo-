using BaseSource.BackendApi.Services.Serivce.CuaHang_TransactionLog;
using BaseSource.BackendApi.Services.Serivce.HopDong;
using BaseSource.Data.EF;
using BaseSource.Data.Entities;
using BaseSource.Shared.Enums;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.CuaHang;
using BaseSource.ViewModels.CuaHang_TransactionLog;
using BaseSource.ViewModels.HopDong;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace BaseSource.BackendApi.Controllers
{
    public class CuaHangController : BaseApiController
    {
        private readonly BaseSourceDbContext _db;
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly IHopDongService _hopDongService;
        private readonly ICuaHang_TransactionLogService _cuaHang_TransactionLogService;
        public CuaHangController(BaseSourceDbContext db, UserManager<AppUser> userManager,
            IServiceScopeFactory serviceScopeFactory, IConfiguration configuration, IHopDongService hopDongService,
            ICuaHang_TransactionLogService cuaHang_TransactionLogService)
        {
            _db = db;
            _userManager = userManager;
            _serviceScopeFactory = serviceScopeFactory;
            _configuration = configuration;
            _hopDongService = hopDongService;
            _cuaHang_TransactionLogService = cuaHang_TransactionLogService;
        }
        #region đăng ký cửa hàng

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterCuaHangVm model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }

            var newUser = new AppUser()
            {
                UserName = model.UserName,
                EmailConfirmed = true,
                PhoneNumber = model.PhoneNumber
            };

            var result = await _userManager.CreateAsync(newUser, model.Password);
            if (result.Succeeded)
            {
                var lstRole = new List<string>(new string[] { "ShopManager" });
                await _userManager.AddToRolesAsync(newUser, lstRole);

                var userProfile = new UserProfile()
                {
                    CustomId = newUser.Id,
                    FullName = model.FullName,
                    JoinedDate = DateTime.Now,
                    UserId = newUser.Id
                };

                var cuaHang = new CuaHang()
                {
                    Ten = model.TenCuaHang,
                    SDT = model.PhoneNumber,
                    DiaChi = model.Address,
                    TenNguoiDaiDien = model.FullName,
                    VonDauTu = model.VonDauTu,
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    UserId = newUser.Id,
                    UserProfileQuanLy = userProfile
                };
                _db.CuaHangs.Add(cuaHang);

                await _db.SaveChangesAsync();

                //add vốn đầu tư
                await KhoiTaoNguonVon(cuaHang.SDT, cuaHang.DiaChi, cuaHang.VonDauTu, cuaHang.Id);

                await KhoiTaoHangHoa(cuaHang.Id);
                return Ok(new ApiSuccessResult<string>());
            }

            AddErrors(result, nameof(model.UserName));
            return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));

        }
        #endregion

        #region quản lý cửa hàng
        [HttpGet("GetPagings")]
        public async Task<IActionResult> GetPagings([FromQuery] GetCuaHangPagingRequest request)
        {
            var model = _db.CuaHangs.AsQueryable();

            if (!string.IsNullOrEmpty(request.Ten))
            {
                model = model.Where(x => x.Ten.Contains(request.Ten));
            }
            if (!string.IsNullOrEmpty(request.Status))
            {
                if (request.Status == "1")
                {
                    model = model.Where(x => x.IsActive == true);
                }
                else
                {
                    model = model.Where(x => !x.IsActive);
                }
            }


            var data = await model.Select(x => new CuaHangVm()
            {
                Id = x.Id,
                Ten = x.Ten,
                DiaChi = x.DiaChi,
                SDT = x.SDT,
                TenNguoiDaiDien = x.TenNguoiDaiDien,
                VonDauTu = x.VonDauTu,
                IsActive = x.IsActive,
                CreatedDate = x.CreatedDate,
            }).OrderByDescending(x => x.CreatedDate).ToPagedListAsync(request.Page, request.PageSize);

            var pagedResult = new PagedResult<CuaHangVm>()
            {
                TotalItemCount = data.TotalItemCount,
                PageSize = data.PageSize,
                PageNumber = data.PageNumber,
                Items = data.ToList()
            };
            return Ok(new ApiSuccessResult<PagedResult<CuaHangVm>>(pagedResult));
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var x = await _db.CuaHangs.FindAsync(id);
            if (x == null)
            {
                return Ok(new ApiErrorResult<string>("Not found"));
            }
            var result = new CuaHangVm()
            {
                Id = x.Id,
                Ten = x.Ten,
                DiaChi = x.DiaChi,
                SDT = x.SDT,
                TenNguoiDaiDien = x.TenNguoiDaiDien,
                VonDauTu = x.VonDauTu,
                IsActive = x.IsActive,
            };

            return Ok(new ApiSuccessResult<CuaHangVm>(result));
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateCuaHangVm model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }

            var cuaHang = new CuaHang();
            cuaHang.Ten = model.TenCuaHang;
            cuaHang.SDT = model.SDT;
            cuaHang.DiaChi = model.DiaChi;
            cuaHang.TenNguoiDaiDien = model.TenNguoiDaiDien;
            cuaHang.VonDauTu = model.VonDauTu;
            cuaHang.CreatedDate = DateTime.Now;
            cuaHang.IsActive = model.IsActive;
            cuaHang.UserId = UserId;
            _db.CuaHangs.Add(cuaHang);

            await _db.SaveChangesAsync();

            //add vốn đầu tư
            await KhoiTaoNguonVon(cuaHang.SDT, cuaHang.DiaChi, cuaHang.VonDauTu, cuaHang.Id);

            await KhoiTaoHangHoa(cuaHang.Id);
            return Ok(new ApiSuccessResult<string>(cuaHang.Id.ToString()));
        }

        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(EditCuaHangVm model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }

            var cuaHang = await _db.CuaHangs.FindAsync(model.Id);
            if (cuaHang == null)
            {
                return Ok(new ApiErrorResult<string>("Not found"));
            }
            cuaHang.Ten = model.TenCuaHang;
            cuaHang.SDT = model.SDT;
            cuaHang.DiaChi = model.DiaChi;
            cuaHang.TenNguoiDaiDien = model.TenNguoiDaiDien;
            cuaHang.VonDauTu = model.VonDauTu;
            cuaHang.CreatedDate = DateTime.Now;
            cuaHang.IsActive = model.IsActive;

            await _db.SaveChangesAsync();
            return Ok(new ApiSuccessResult<string>(cuaHang.Id.ToString()));
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromForm] int id)
        {
            var cuaHang = await _db.CuaHangs.FindAsync(id);
            if (cuaHang != null)
            {
                _db.CuaHangs.Remove(cuaHang);
                await _db.SaveChangesAsync();
                return Ok(new ApiSuccessResult<string>());
            }
            return Ok(new ApiErrorResult<string>("Not Found!"));
        }
        [HttpPost("ChangeShop")]
        public async Task<IActionResult> ChangeShop([FromForm] int id)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var user = await _db.Users.FindAsync(UserId);
            var roles = await _userManager.GetRolesAsync(user);
            var cuaHang = await _db.CuaHangs.FindAsync(id);
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email,user.Email ?? ""),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim("CuaHangId", id.ToString()),
                 new Claim("TenCuaHang", cuaHang?.Ten??"")
             };

            foreach (var item in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, item));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration["Tokens:Issuer"],
             _configuration["Tokens:Issuer"],
             claims,
             expires: DateTime.UtcNow.AddDays(15),
             signingCredentials: creds);

            var jwtToken = jwtTokenHandler.WriteToken(token);
            return Ok(new ApiSuccessResult<string>(jwtToken));
        }
        [HttpGet("GetShopByUser")]
        public async Task<IActionResult> GetShopByUser()
        {
            var lstShop = await _db.CuaHangs.Where(x => x.UserId == UserId).ToListAsync();
            var lstResult = new List<CuaHangVm>();
            foreach (var item in lstShop)
            {
                lstResult.Add(new CuaHangVm()
                {
                    Id = item.Id,
                    Ten = item.Ten
                });
            }

            return Ok(new ApiSuccessResult<List<CuaHangVm>>(lstResult));
        }



        #endregion

        #region helper

        private async Task KhoiTaoNguonVon(string sdt, string diaChi, long vonDauTu, int cuaHangId)
        {
            var resultHopDong = await _hopDongService.CreateHopDongAsync(new CreateHopDongVm
            {
                SDT = sdt,
                TenKhachHang = "Vốn Khởi Tạo",
                DiaChi = diaChi,
                HD_Loai = ELoaiHopDong.GopVon,
                UserIdAssigned = UserId,
                HD_NgayVay = DateTime.Now,
                HD_TongTienVayBanDau = vonDauTu,
                HD_Ma = Guid.NewGuid().ToString(),
                TenTaiSan = "Vốn Khởi Tạo"
            }, cuaHangId, UserId);

            if (resultHopDong.Key)
            {
                //add log cuahang
                await _cuaHang_TransactionLogService.CreateTransactionLog(new CreateCuaHang_TransactionLogVm
                {
                    HopDongId = int.Parse(resultHopDong.Value),
                    ActionType = EHopDong_ActionType.TaoMoiHD,
                    FeatureType = EFeatureType.GopVon,
                    UserId = UserId,
                    TotalMoneyLoan = vonDauTu
                });
            }
        }

        private async Task KhoiTaoHangHoa(int cuahangId)
        {
            var lstHangHoaDefault = await _db.CauHinhHangHoas.Where(x => x.CuaHangId == null && x.IsPublish == true).ToListAsync();
            if (lstHangHoaDefault.Count > 0)
            {
                var lstHangHoa = lstHangHoaDefault.Select(c => { c.CuaHangId = cuahangId; c.Id = 0; return c; }).ToList();
                _db.CauHinhHangHoas.AddRange(lstHangHoa);
                await _db.SaveChangesAsync();
            }
        }

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
