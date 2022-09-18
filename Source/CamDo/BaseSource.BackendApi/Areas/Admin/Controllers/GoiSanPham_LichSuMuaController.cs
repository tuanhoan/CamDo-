using BaseSource.Data.EF;
using BaseSource.Data.Entities;
using BaseSource.ViewModels.Admin;
using BaseSource.ViewModels.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace BaseSource.BackendApi.Areas.Admin.Controllers
{
    public class GoiSanPham_LichSuMuaController : BaseAdminApiController
    {
        private readonly BaseSourceDbContext _db;
        public GoiSanPham_LichSuMuaController(BaseSourceDbContext db)
        {
            _db = db;
        }
        [HttpGet("GetPagings")]
        public async Task<IActionResult> GetPagings([FromQuery] GoiSanPham_LichSuMuaQr request)
        {
            var model = _db.GoiSanPham_LichSuMuas
                .AsQueryable();
            if (!string.IsNullOrEmpty(request.Info))
            {
                //model = model.Where(x => x.Ten.Contains(request.Info));
            }

            var data = await model.Select(x => new GoiSanPham_LichSuMuaVM()
            {
                Id = x.Id,
                UserId = x.UserId,
                GoiSanPhamId = x.GoiSanPhamId,
                TenGoi = x.TenGoi,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                TongTien = x.TongTien,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
            }).OrderByDescending(x => x.CreatedDate).ToPagedListAsync(request.Page, request.PageSize);

            var pagedResult = new PagedResult<GoiSanPham_LichSuMuaVM>()
            {
                TotalItemCount = data.TotalItemCount,
                PageSize = data.PageSize,
                PageNumber = data.PageNumber,
                Items = data.ToList()
            };
            return Ok(new ApiSuccessResult<PagedResult<GoiSanPham_LichSuMuaVM>>(pagedResult));
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var x = await _db.GoiSanPham_LichSuMuas.FindAsync(id);
            if (x == null)
            {
                return Ok(new ApiErrorResult<string>("Not found"));
            }
            var result = new GoiSanPham_LichSuMuaVM()
            {
                Id = x.Id,
                UserId = x.UserId,
                GoiSanPhamId = x.GoiSanPhamId,
                TenGoi = x.TenGoi,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                TongTien = x.TongTien,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
            };
            return Ok(new ApiSuccessResult<GoiSanPham_LichSuMuaVM>(result));
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(GoiSanPham_LichSuMuaCreate model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }

            var sp = new GoiSanPham_LichSuMua()
            {
                UserId = model.UserId,
                GoiSanPhamId = model.GoiSanPhamId,
                TenGoi = model.TenGoi,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                TongTien = model.TongTien,
                CreatedBy = UserId,
                CreatedDate = DateTime.Now,
            };

            _db.GoiSanPham_LichSuMuas.Add(sp);
            await _db.SaveChangesAsync();
            return Ok(new ApiSuccessResult<string>(sp.Id.ToString()));
        }
        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(GoiSanPham_LichSuMuaEdit model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var x = await _db.GoiSanPham_LichSuMuas.FindAsync(model.Id);
            if (x == null)
            {
                return Ok(new ApiErrorResult<string>("Not found"));
            }
            x.GoiSanPhamId = model.GoiSanPhamId;
            x.TenGoi = model.TenGoi;
            x.StartDate = model.StartDate;
            x.EndDate = model.EndDate;
            x.TongTien = model.TongTien;
            await _db.SaveChangesAsync();

            return Ok(new ApiSuccessResult<string>(x.Id.ToString()));
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromForm] int id)
        {
            var sp = await _db.GoiSanPham_LichSuMuas.FindAsync(id);
            if (sp != null)
            {
                _db.GoiSanPham_LichSuMuas.Remove(sp);
                await _db.SaveChangesAsync();
                return Ok(new ApiSuccessResult<string>());
            }
            return Ok(new ApiErrorResult<string>("Not Found!"));
        }
    }
}
