using BaseSource.Data.EF;
using BaseSource.Data.Entities;
using BaseSource.ViewModels.Admin;
using BaseSource.ViewModels.Common;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace BaseSource.BackendApi.Areas.Admin.Controllers
{
    public class DanhMucBaiVietController : BaseAdminApiController
    {
        private readonly BaseSourceDbContext _db;
        public DanhMucBaiVietController(BaseSourceDbContext db)
        {
            _db = db;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var model = _db.DanhMucBaiViets.AsQueryable();

            var data = await model.Select(x => new DanhMucBaiVietAdminVm()
            {
                Id = x.Id,
                Name = x.Name,
                DisableDelete = x.DisableDelete,
                CreatedTime = x.CreatedTime
            }).ToListAsync();

            return base.Ok(new ApiSuccessResult<List<DanhMucBaiVietAdminVm>>(data));
        }

        [HttpGet("GetPagings")]
        public async Task<IActionResult> GetPagings([FromQuery] GetDanhMucBaiVietPagingRequest_Admin request)
        {
            var model = _db.DanhMucBaiViets.AsQueryable();

            var data = await model.Select(x => new DanhMucBaiVietAdminVm()
            {
                Id = x.Id,
                Name = x.Name,
                DisableDelete = x.DisableDelete,
                CreatedTime = x.CreatedTime
            }).ToPagedListAsync(request.Page, request.PageSize);

            var pagedResult = new PagedResult<DanhMucBaiVietAdminVm>()
            {
                TotalItemCount = data.TotalItemCount,
                PageSize = data.PageSize,
                PageNumber = data.PageNumber,
                Items = data.ToList()
            };

            return base.Ok(new ApiSuccessResult<PagedResult<DanhMucBaiVietAdminVm>>(pagedResult));
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var x = await _db.DanhMucBaiViets.FindAsync(id);

            if (x == null)
            {
                return Ok(new ApiErrorResult<string>("Not found"));
            }

            var result = new DanhMucBaiVietAdminVm()
            {
                Id = x.Id,
                Name = x.Name,
                DisableDelete = x.DisableDelete,
                CreatedTime = x.CreatedTime
            };

            return Ok(new ApiSuccessResult<DanhMucBaiVietAdminVm>(result));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateDanhMucBaiVietAdminVm model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }

            var record = new DanhMucBaiViet()
            {
                Name = model.Name,
                CreatedTime = System.DateTime.Now
            };

            _db.DanhMucBaiViets.Add(record);
            await _db.SaveChangesAsync();
            return Ok(new ApiSuccessResult<string>(record.Id.ToString()));
        }

        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(EditDanhMucBaiVietAdminVm model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }

            var x = await _db.DanhMucBaiViets.FindAsync(model.Id);

            if (x == null)
            {
                return Ok(new ApiErrorResult<string>("Not found"));
            }

            x.Name = model.Name;
            
            await _db.SaveChangesAsync();

            return Ok(new ApiSuccessResult<string>(x.Id.ToString()));
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromForm] int id)
        {
            var record = await _db.DanhMucBaiViets.FindAsync(id);
            if (record != null && record.DisableDelete == false)
            {
                _db.DanhMucBaiViets.Remove(record);
                await _db.SaveChangesAsync();
                return Ok(new ApiSuccessResult<string>());
            }
            return Ok(new ApiErrorResult<string>("Not Found!"));
        }
    }
}
