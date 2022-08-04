using BaseSource.Data.EF;
using BaseSource.Data.Entities;
using BaseSource.ViewModels.Admin;
using BaseSource.ViewModels.Common;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace BaseSource.BackendApi.Areas.Admin.Controllers
{
    public class BaiVietController : BaseAdminApiController
    {
        private readonly BaseSourceDbContext _db;
        public BaiVietController(BaseSourceDbContext db)
        {
            _db = db;
        }

        [HttpGet("GetPagings")]
        public async Task<IActionResult> GetPagings([FromQuery] GetBaiVietPagingRequest_Admin request)
        {
            var model = _db.BaiViets.AsQueryable();

            var data = await model.Select(x => new BaiVietAdminVm()
            {
                Id = x.Id,
                Name = x.Name,
                Content = x.Content,
                DanhMucBaiViet = new DanhMucBaiVietAdminVm
                {
                    Id = x.DanhMucBaiViet.Id,
                    Name = x.DanhMucBaiViet.Name,
                    CreatedTime = x.DanhMucBaiViet.CreatedTime,
                },
                Url = x.Url,
                CreatedTime = x.CreatedTime
            }).OrderByDescending(x => x.Id).ToPagedListAsync(request.Page, request.PageSize);

            var pagedResult = new List<BaiVietAdminVm>()
            {
                TotalItemCount = data.TotalItemCount,
                PageSize = data.PageSize,
                PageNumber = data.PageNumber,
                Items = data.ToList()
            };

            return Ok(new ApiSuccessResult<List<BaiVietAdminVm>>(pagedResult));
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var x = await _db.BaiViets.FindAsync(id);

            if (x == null)
            {
                return Ok(new ApiErrorResult<string>("Not found"));
            }

            var result = new BaiVietAdminVm()
            {
                Id = x.Id,
                Name = x.Name,
                DanhMucBaiViet = new DanhMucBaiVietAdminVm
                {
                    Id = x.DanhMucBaiViet.Id,
                    Name = x.DanhMucBaiViet.Name,
                    CreatedTime = x.DanhMucBaiViet.CreatedTime,
                },
                Url = x.Url,
                CreatedTime = x.CreatedTime
            };

            return Ok(new ApiSuccessResult<BaiVietAdminVm>(result));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateBaiVietAdminVm model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }

            var record = new BaiViet()
            {
                Name = model.Name,
                DanhMucBaiVietId = model.DanhMucBaiVietId
            };

            _db.BaiViets.Add(record);
            await _db.SaveChangesAsync();
            return Ok(new ApiSuccessResult<string>(record.Id.ToString()));
        }

        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(EditBaiVietAdminVm model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }

            var x = await _db.BaiViets.FindAsync(model.Id);

            if (x == null)
            {
                return Ok(new ApiErrorResult<string>("Not found"));
            }

            x.Name = model.Name;
            x.DanhMucBaiVietId = model.DanhMucBaiVietId;
            x.Content = model.Content;
            x.Url = model.Url;

            await _db.SaveChangesAsync();

            return Ok(new ApiSuccessResult<string>(x.Id.ToString()));
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromForm] int id)
        {
            var record = await _db.BaiViets.FindAsync(id);
            if (record != null)
            {
                _db.BaiViets.Remove(record);
                await _db.SaveChangesAsync();
                return Ok(new ApiSuccessResult<string>());
            }
            return Ok(new ApiErrorResult<string>("Not Found!"));
        }
    }
}
