using BaseSource.Data.EF;
using BaseSource.ViewModels.Admin;
using BaseSource.ViewModels.Common;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace BaseSource.BackendApi.Areas.Admin.Controllers
{
    public class LienHeController : BaseAdminApiController
    {
        private readonly BaseSourceDbContext _db;
        public LienHeController(BaseSourceDbContext db)
        {
            _db = db;
        }

        [HttpGet("GetPagings")]
        public async Task<IActionResult> GetPagings([FromQuery] GetLienHePagingRequest_Admin request)
        {
            var model = _db.LienHes.AsQueryable();

            var data = await model.Select(x => new LienHeAdminVm()
            {
                Id = x.Id,
                Name = x.Name,
                Phone = x.Phone,
                Email = x.Email,
                Message = x.Message,
                IsRead = x.IsRead,
                CreatedTime = x.CreatedTime
            }).OrderByDescending(x => x.Id).ToPagedListAsync(request.Page, request.PageSize);

            var pagedResult = new PagedResult<LienHeAdminVm>()
            {
                TotalItemCount = data.TotalItemCount,
                PageSize = data.PageSize,
                PageNumber = data.PageNumber,
                Items = data.ToList()
            };
            return Ok(new ApiSuccessResult<PagedResult<LienHeAdminVm>>(pagedResult));
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var x = await _db.LienHes.FindAsync(id);
            if (x == null)
            {
                return Ok(new ApiErrorResult<string>("Not found"));
            }

            var result = new LienHeAdminVm()
            {
                Id = x.Id,
                Name = x.Name,
                Phone = x.Phone,
                Email = x.Email,
                Message = x.Message,
                IsRead = x.IsRead,
                CreatedTime = x.CreatedTime
            };

            x.IsRead = true;

            await _db.SaveChangesAsync();

            return Ok(new ApiSuccessResult<LienHeAdminVm>(result));
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromForm] int id)
        {
            var sp = await _db.LienHes.FindAsync(id);
            if (sp != null)
            {
                _db.LienHes.Remove(sp);
                await _db.SaveChangesAsync();
                return Ok(new ApiSuccessResult<string>());
            }
            return Ok(new ApiErrorResult<string>("Not Found!"));
        }
    }
}
