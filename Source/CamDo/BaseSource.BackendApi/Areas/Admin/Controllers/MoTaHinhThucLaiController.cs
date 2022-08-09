using BaseSource.Data.EF;
using BaseSource.Data.Entities;
using BaseSource.Shared.Enums;
using BaseSource.Utilities.Extensions;
using BaseSource.ViewModels.Admin;
using BaseSource.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace BaseSource.BackendApi.Areas.Admin.Controllers
{

    public class MoTaHinhThucLaiController : BaseAdminApiController
    {
        private readonly BaseSourceDbContext _db;
        public MoTaHinhThucLaiController(BaseSourceDbContext db)
        {
            _db = db;
        }
        [HttpGet("GetPagings")]
        public async Task<IActionResult> GetPagings([FromQuery] GetMoTaHinhThucLaiPagingRequest_Admin request)
        {
            var model = _db.MoTaHinhThucLais.AsQueryable();

            if (request.HinhThucLai != 0)
            {
                var lai = (EHinhThucLai)request.HinhThucLai;
                model = model.Where(x => x.HinhThucLai == lai);
            }

            var data = await model.Select(x => new MoTaHinhThucLaiAdminVm()
            {
                Id = x.Id,
                HinhThucLai = x.HinhThucLai.GetValueOrDefault(),
                MoTaKyLai = x.MoTaKyLai,
                TyLeLai = x.TyLeLai,
                ThoiGian = x.ThoiGian
            }).OrderByDescending(x => x.Id).ToPagedListAsync(request.Page, request.PageSize);

            var pagedResult = new PagedResult<MoTaHinhThucLaiAdminVm>()
            {
                TotalItemCount = data.TotalItemCount,
                PageSize = data.PageSize,
                PageNumber = data.PageNumber,
                Items = data.ToList()
            };
            return Ok(new ApiSuccessResult<PagedResult<MoTaHinhThucLaiAdminVm>>(pagedResult));
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var x = await _db.MoTaHinhThucLais.FindAsync(id);
            if (x == null)
            {
                return Ok(new ApiErrorResult<string>("Not found"));
            }
            var result = new MoTaHinhThucLaiAdminVm()
            {
                Id = x.Id,
                HinhThucLai = x.HinhThucLai.GetValueOrDefault(),
                MoTaKyLai = x.MoTaKyLai,
                TyLeLai = x.TyLeLai,
                ThoiGian = x.ThoiGian
            };
            return Ok(new ApiSuccessResult<MoTaHinhThucLaiAdminVm>(result));
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateMoTaHinhThucLaiAdminVm model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var old = await _db.MoTaHinhThucLais.FirstOrDefaultAsync(x => x.HinhThucLai == model.HinhThucLai);
            if (old != null)
            {
                ModelState.AddModelError("HinhThucLai", "Hình thức lãi đã tồn tại trong hệ thống");
                return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }

            var mota = new MoTaHinhThucLai()
            {
                HinhThucLai = model.HinhThucLai,
                MoTaKyLai = model.MoTaKyLai,
                TyLeLai = model.TyLeLai,
                ThoiGian = model.ThoiGian
            };

            _db.MoTaHinhThucLais.Add(mota);
            await _db.SaveChangesAsync();
            return Ok(new ApiSuccessResult<string>(mota.Id.ToString()));
        }
        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(EditMoTaHinhThucLaiAdminVm model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var mota = await _db.MoTaHinhThucLais.FindAsync(model.Id);
            if (mota == null)
            {
                return Ok(new ApiErrorResult<string>("Not found"));
            }
            var old = await _db.MoTaHinhThucLais.FirstOrDefaultAsync(x => x.HinhThucLai == model.HinhThucLai && x.Id != model.Id);
            if (old != null)
            {
                ModelState.AddModelError("HinhThucLai", "Hình thức lãi đã tồn tại trong hệ thống");
                return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }

            mota.MoTaKyLai = model.MoTaKyLai;
            mota.TyLeLai = model.TyLeLai;
            mota.ThoiGian = model.ThoiGian;

            await _db.SaveChangesAsync();
            return Ok(new ApiSuccessResult<string>(mota.Id.ToString()));
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromForm] int id)
        {
            var x = await _db.GoiSanPhams.FindAsync(id);
            if (x != null)
            {
                _db.GoiSanPhams.Remove(x);
                await _db.SaveChangesAsync();
                return Ok(new ApiSuccessResult<string>());
            }
            return Ok(new ApiErrorResult<string>("Not Found!"));
        }
    }
}
