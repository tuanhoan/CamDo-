using BaseSource.Data.EF;
using BaseSource.Data.Entities;
using BaseSource.Shared.Enums;
using BaseSource.ViewModels.Admin;
using BaseSource.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace BaseSource.BackendApi.Areas.Admin.Controllers
{

    public class CauHinhHangHoaController : BaseAdminApiController
    {
        private readonly BaseSourceDbContext _db;
        public CauHinhHangHoaController(BaseSourceDbContext db)
        {
            _db = db;
        }
        [HttpGet("GetPagings")]
        public async Task<IActionResult> GetPagings([FromQuery] GetCauHinhHangHoaPagingRequest_Admin request)
        {
            var model = _db.CauHinhHangHoas.AsQueryable();
            model = model.Where(x => x.CuaHangId == null);
            if (!string.IsNullOrEmpty(request.Ten))
            {
                model = model.Where(x => x.Ten.Contains(request.Ten));
            }
            if (request.LinhVuc != 0)
            {
                var lv = (ELinhVucHangHoa)request.LinhVuc;
                model = model.Where(x => x.LinhVuc == lv);
            }
            if (request.Status != null)
            {
                if (request.Status == 1)
                {
                    model = model.Where(x => x.IsPublish == true);
                }
                else
                {
                    model = model.Where(x => x.IsPublish == false);
                }
            }

            var data = await model.Select(x => new CauHinhHangHoaAdminVm()
            {
                Id = x.Id,
                LinhVuc = x.LinhVuc,
                Ten = x.Ten,
                MaTS = x.MaTS,
                TongTien = x.TongTien,
                LaiSuat = x.LaiSuat,
                KyLai = x.KyLai,
                SoNgayQuaHan = x.SoNgayQuaHan,
                IsPublish = x.IsPublish,
            }).OrderByDescending(x => x.Id).ToPagedListAsync(request.Page, request.PageSize);

            var pagedResult = new PagedResult<CauHinhHangHoaAdminVm>()
            {
                TotalItemCount = data.TotalItemCount,
                PageSize = data.PageSize,
                PageNumber = data.PageNumber,
                Items = data.ToList()
            };
            return Ok(new ApiSuccessResult<PagedResult<CauHinhHangHoaAdminVm>>(pagedResult));
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var x = await _db.CauHinhHangHoas.FindAsync(id);
            if (x == null)
            {
                return Ok(new ApiErrorResult<string>("Not found"));
            }
            var result = new CauHinhHangHoaAdminVm()
            {
                Id = x.Id,
                LinhVuc = x.LinhVuc,
                Ten = x.Ten,
                MaTS = x.MaTS,
                IsPublish = x.IsPublish,
                HinhThucLai = x.HinhThucLai,
                TongTien = x.TongTien,
                LaiSuat = x.LaiSuat,
                KyLai = x.KyLai,
                TongThoiGianVay = x.TongThoiGianVay,
                SoNgayQuaHan = x.SoNgayQuaHan,
                IsThuLaiTruoc = x.IsThuLaiTruoc,
                ListThuocTinh = x.ListThuocTinh
            };
            return Ok(new ApiSuccessResult<CauHinhHangHoaAdminVm>(result));
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateCauHinhHangHoaAdminVm model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }

            var hanghoa = new CauHinhHangHoa()
            {
                LinhVuc = model.LinhVuc,
                Ten = model.Ten,
                MaTS = model.MaTS,
                IsPublish = model.IsPublish,
                HinhThucLai = model.HinhThucLai,
                TongTien = model.TongTien,
                LaiSuat = model.LaiSuat,
                KyLai = model.KyLai,
                TongThoiGianVay = model.TongThoiGianVay,
                SoNgayQuaHan = model.SoNgayQuaHan,
                IsThuLaiTruoc = model.IsThuLaiTruoc,
                ListThuocTinh = JsonConvert.SerializeObject(model.ListThuocTinh)
            };

            _db.CauHinhHangHoas.Add(hanghoa);
            await _db.SaveChangesAsync();
            return Ok(new ApiSuccessResult<string>(hanghoa.Id.ToString()));
        }
        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(EditCauHinhHangHoaAdminVm model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var hanghoa = await _db.CauHinhHangHoas.FindAsync(model.Id);
            if (hanghoa == null)
            {
                return Ok(new ApiErrorResult<string>("Not found"));
            }

            hanghoa.LinhVuc = model.LinhVuc;
            hanghoa.Ten = model.Ten;
            hanghoa.MaTS = model.MaTS;
            hanghoa.IsPublish = model.IsPublish;
            hanghoa.HinhThucLai = model.HinhThucLai;
            hanghoa.TongTien = model.TongTien;
            hanghoa.LaiSuat = model.LaiSuat;
            hanghoa.KyLai = model.KyLai;
            hanghoa.TongThoiGianVay = model.TongThoiGianVay;
            hanghoa.SoNgayQuaHan = model.SoNgayQuaHan;
            hanghoa.IsThuLaiTruoc = model.IsThuLaiTruoc;
            hanghoa.ListThuocTinh = JsonConvert.SerializeObject(model.ListThuocTinh);

            await _db.SaveChangesAsync();
            return Ok(new ApiSuccessResult<string>(hanghoa.Id.ToString()));;
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromForm] int id)
        {
            var hanghoa = await _db.CauHinhHangHoas.FindAsync(id);
            if (hanghoa != null)
            {
                _db.CauHinhHangHoas.Remove(hanghoa);
                await _db.SaveChangesAsync();
                return Ok(new ApiSuccessResult<string>());
            }
            return Ok(new ApiErrorResult<string>("Not Found!"));
        }
    }
}
