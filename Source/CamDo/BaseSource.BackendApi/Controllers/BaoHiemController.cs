using BaseSource.Data.EF;
using BaseSource.Data.Entities;
using BaseSource.ViewModels.BaiViet;
using BaseSource.ViewModels.BaoHiem;
using BaseSource.ViewModels.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace BaseSource.BackendApi.Controllers
{
    public class BaoHiemController : BaseApiController
    {
        private readonly BaseSourceDbContext _db;
        public BaoHiemController(BaseSourceDbContext db)
        {
            _db = db;
        }

        [HttpGet("GetPagings")]
        public async Task<IActionResult> GetPagings([FromQuery] BaohiemQr request)
        {
            var data = await (from bh in _db.BaoHiems
                              join uf in _db.UserProfiles on bh.UserId equals uf.UserId
                              join ch in _db.CuaHangs on bh.CuaHangId equals ch.Id
                              where (request.FromDate <= bh.StartDate || request.FromDate == default)
                                  && (request.ToDate >= bh.StartDate || request.ToDate == default)
                              orderby bh.Id descending
                              select new BaoHiemVm()
                              {
                                  Id = bh.Id,
                                  CuaHangId = bh.CuaHangId,
                                  CuaHangName = ch.Ten,
                                  UserId = bh.UserId,
                                  UserName = uf.FullName,
                                  Ten = bh.Ten,
                                  SDT = bh.SDT,
                                  GioiTinh = bh.GioiTinh,
                                  NgaySinh = bh.NgaySinh,
                                  CMND = bh.CMND,
                                  CMND_NgayCap = bh.CMND_NgayCap,
                                  CMND_NoiCap = bh.CMND_NoiCap,
                                  Email = bh.Email,
                                  MST = bh.MST,
                                  DiaChi = bh.DiaChi,
                                  StartDate = bh.StartDate,
                                  EndDate = bh.EndDate,
                                  ImageList = bh.ImageList,
                                  TienBaoHiem = bh.TienBaoHiem,
                                  TienPhi = bh.TienPhi,
                                  TienChietKhau = bh.TienChietKhau,
                                  TongTien = bh.TongTien,
                                  Type = bh.Type

                              }).ToPagedListAsync(request.Page, request.PageSize);

            var pagedResult = new PagedResult<BaoHiemVm>()
            {
                TotalItemCount = data.TotalItemCount,
                PageSize = data.PageSize,
                PageNumber = data.PageNumber,
                Items = data.ToList()
            };
            return Ok(new ApiSuccessResult<PagedResult<BaoHiemVm>>(pagedResult));
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var rs = await (from bh in _db.BaoHiems
                            join uf in _db.UserProfiles on bh.UserId equals uf.UserId
                            join ch in _db.CuaHangs on bh.CuaHangId equals ch.Id
                            where ch.Id == id
                            select new BaoHiemVm()
                            {
                                Id = bh.Id,
                                CuaHangId = bh.CuaHangId,
                                CuaHangName = ch.Ten,
                                UserId = bh.UserId,
                                UserName = uf.FullName,
                                Ten = bh.Ten,
                                SDT = bh.SDT,
                                GioiTinh = bh.GioiTinh,
                                NgaySinh = bh.NgaySinh,
                                CMND = bh.CMND,
                                CMND_NgayCap = bh.CMND_NgayCap,
                                CMND_NoiCap = bh.CMND_NoiCap,
                                Email = bh.Email,
                                MST = bh.MST,
                                DiaChi = bh.DiaChi,
                                StartDate = bh.StartDate,
                                EndDate = bh.EndDate,
                                ImageList = bh.ImageList,
                                TienBaoHiem = bh.TienBaoHiem,
                                TienPhi = bh.TienPhi,
                                TienChietKhau = bh.TienChietKhau,
                                TongTien = bh.TongTien,
                            }).FirstOrDefaultAsync();
            if (rs == null)
            {
                return Ok(new ApiErrorResult<string>("Not found"));
            }

            return Ok(new ApiSuccessResult<BaoHiemVm>(rs));
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(BaoHiemCreate model)
        {
            model.CuaHangId = CuaHangId;
            model.UserId = UserId;
            if (!ModelState.IsValid)
            {
                return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var sp = new BaoHiem()
            {
                CuaHangId     = model.CuaHangId,
                UserId        = model.UserId,
                Ten           = model.Ten,
                SDT           = model.SDT,
                GioiTinh      = model.GioiTinh,
                NgaySinh      = model.NgaySinh,
                CMND          = model.CMND,
                CMND_NgayCap  = model.CMND_NgayCap,
                CMND_NoiCap   = model.CMND_NoiCap,
                Email         = model.Email,
                MST           = model.MST,
                DiaChi        = model.DiaChi,
                StartDate     = model.StartDate,
                EndDate       = model.StartDate.AddDays(model.ThoiGianMua),
                //ImageList     = model.ImageList,
                TienBaoHiem   = model.TienBaoHiem,
                TienPhi       = model.TienPhi,
                TienChietKhau = model.TienChietKhau,
                TongTien      = model.TongTien,
                Type          = model.Type,
            };

            _db.BaoHiems.Add(sp);
            await _db.SaveChangesAsync();
            return Ok(new ApiSuccessResult<string>("Success"));
        }
        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(BaoHiemEdit model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var x = await _db.BaoHiems.FindAsync(model.Id);
            if (x == null)
            {
                return Ok(new ApiErrorResult<string>("Not found"));
            }
            x.Id            = model.Id;
            x.CuaHangId     = model.CuaHangId;
            x.UserId        = model.UserId;
            x.Ten           = model.Ten;
            x.SDT           = model.SDT;
            x.GioiTinh      = model.GioiTinh;
            x.NgaySinh      = model.NgaySinh;
            x.CMND          = model.CMND;
            x.CMND_NgayCap  = model.CMND_NgayCap;
            x.CMND_NoiCap   = model.CMND_NoiCap;
            x.Email         = model.Email;
            x.MST           = model.MST;
            x.DiaChi        = model.DiaChi;
            x.StartDate     = model.StartDate;
            x.EndDate       = model.StartDate.AddDays(model.ThoiGianMua);
            x.ImageList     = model.ImageList;
            x.TienBaoHiem   = model.TienBaoHiem;
            x.TienPhi       = model.TienPhi;
            x.TienChietKhau = model.TienChietKhau;
            x.TongTien      = model.TongTien;
            await _db.SaveChangesAsync();

            return Ok(new ApiSuccessResult<string>(x.Id.ToString()));
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromForm] int id)
        {
            var sp = await _db.BaoHiems.FindAsync(id);
            if (sp != null)
            {
                _db.BaoHiems.Remove(sp);
                await _db.SaveChangesAsync();
                return Ok(new ApiSuccessResult<string>());
            }
            return Ok(new ApiErrorResult<string>("Not Found!"));
        }
    }
}
