using BaseSource.Data.EF;
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
    public class FeedBackController : BaseAdminApiController
    {
        private readonly BaseSourceDbContext _db;
        public FeedBackController(BaseSourceDbContext db)
        {
            _db = db;
        }
        [HttpGet("GetPagings")]
        public async Task<IActionResult> GetPagings([FromQuery] GetFeedBackPagingRequest_Admin request)
        {
            var model = _db.FeedBacks.AsQueryable();

            var data = await model.Select(x => new FeedBackAdminVm()
            {
                Id = x.Id,
                FeedBackContent = x.FeedBackContent,
                UserFeedBack = x.UserFeedBack,
                TenCuaHang = x.TenCuaHang,
                CreatedTime = x.CreatedTime
            }).OrderByDescending(x => x.Id).ToPagedListAsync(request.Page, request.PageSize);

            var pagedResult = new PagedResult<FeedBackAdminVm>()
            {
                TotalItemCount = data.TotalItemCount,
                PageSize = data.PageSize,
                PageNumber = data.PageNumber,
                Items = data.ToList()
            };
            return Ok(new ApiSuccessResult<PagedResult<FeedBackAdminVm>>(pagedResult));
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromForm] int id)
        {
            var item = await _db.FeedBacks.FindAsync(id);
            if (item != null)
            {
                _db.FeedBacks.Remove(item);
                await _db.SaveChangesAsync();
                return Ok(new ApiSuccessResult<string>());
            }
            return Ok(new ApiErrorResult<string>("Not Found!"));
        }
    }
}
