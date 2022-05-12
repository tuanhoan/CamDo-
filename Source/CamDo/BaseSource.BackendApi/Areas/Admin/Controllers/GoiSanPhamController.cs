using BaseSource.Data.EF;
using BaseSource.Data.Entities;
using BaseSource.ViewModels.Admin;
using BaseSource.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace BaseSource.BackendApi.Areas.Admin.Controllers
{
    public class GoiSanPhamController : BaseAdminApiController
    {
        private readonly BaseSourceDbContext _db;
        public GoiSanPhamController(BaseSourceDbContext db)
        {
            _db = db;
        }
        [HttpGet("GetPagings")]
        public async Task<IActionResult> GetPagings([FromQuery] GetGoiSanPhamPagingRequest_Admin request)
        {
            var model = _db.GoiSanPhams.AsQueryable();

            if (!string.IsNullOrEmpty(request.Info))
            {
                model = model.Where(x => x.Ten.Contains(request.Info));
            }

            var data = await model.Select(x => new GoiSanPhamAdminVm()
            {
                Id = x.Id,
                Ten = x.Ten,
                TongTien = x.TongTien,
                SoThang = x.SoThang,
                KhuyenMai = x.KhuyenMai,
                CreatedTime = x.CreatedTime
            }).OrderByDescending(x => x.Id).ToPagedListAsync(request.Page, request.PageSize);

            var pagedResult = new PagedResult<GoiSanPhamAdminVm>()
            {
                TotalItemCount = data.TotalItemCount,
                PageSize = data.PageSize,
                PageNumber = data.PageNumber,
                Items = data.ToList()
            };
            return Ok(new ApiSuccessResult<PagedResult<GoiSanPhamAdminVm>>(pagedResult));
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var x = await _db.GoiSanPhams.FindAsync(id);
            if (x == null)
            {
                return Ok(new ApiErrorResult<string>("Not found"));
            }
            var result = new GoiSanPhamAdminVm()
            {
                Id = x.Id,
                Ten = x.Ten,
                TongTien = x.TongTien,
                SoThang = x.SoThang,
                MoTa = x.MoTa,
                KhuyenMai = x.KhuyenMai
            };
            return Ok(new ApiSuccessResult<GoiSanPhamAdminVm>(result));
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateGoiSanPhamVm model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var sp = new GoiSanPham()
            {
                Ten = model.Ten,
                TongTien = model.TongTien,
                SoThang = model.SoThang,
                MoTa = model.MoTa,
                KhuyenMai = model.KhuyenMai,
                UserIdCreated=UserId,
            };

            _db.GoiSanPhams.Add(sp);
            await _db.SaveChangesAsync();
            return Ok(new ApiSuccessResult<string>(sp.Id.ToString()));
        }
        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(EditGoiSanPhamVm model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var x = await _db.GoiSanPhams.FindAsync(model.Id);
            if (x == null)
            {
                return Ok(new ApiErrorResult<string>("Not found"));
            }
            x.Ten = model.Ten;
            x.TongTien = model.TongTien;
            x.SoThang = model.SoThang;
            x.MoTa = model.MoTa;
            x.KhuyenMai = model.KhuyenMai;
            x.UserIdUpdate = UserId;
            x.UpdatedTime = DateTime.Now;
            await _db.SaveChangesAsync();

            return Ok(new ApiSuccessResult<string>(x.Id.ToString()));
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromForm] int id)
        {
            var sp = await _db.GoiSanPhams.FindAsync(id);
            if (sp != null)
            {
                _db.GoiSanPhams.Remove(sp);
                await _db.SaveChangesAsync();
                return Ok(new ApiSuccessResult<string>());
            }
            return Ok(new ApiErrorResult<string>("Not Found!"));
        }
    }
}
