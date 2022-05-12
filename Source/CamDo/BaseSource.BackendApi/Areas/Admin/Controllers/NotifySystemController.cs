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
    public class NotifySystemController : BaseAdminApiController
    {
        private readonly BaseSourceDbContext _db;
        public NotifySystemController(BaseSourceDbContext db)
        {
            _db = db;
        }
        [HttpGet("GetPagings")]
        public async Task<IActionResult> GetPagings([FromQuery] GetNotifySystemPagingRequest_Admin request)
        {
            var model = _db.NotifySystems.AsQueryable();
            if (!string.IsNullOrEmpty(request.Info))
            {
                model = model.Where(x => x.Title.Contains(request.Info));
            }
            var data = await model.Select(x => new NotifySystemAdminVm()
            {
                Id = x.Id,
                Title = x.Title,
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                Url = x.Url,
                CreatedTime = x.CreatedTime
            }).OrderByDescending(x => x.Id).ToPagedListAsync(request.Page, request.PageSize);

            var pagedResult = new PagedResult<NotifySystemAdminVm>()
            {
                TotalItemCount = data.TotalItemCount,
                PageSize = data.PageSize,
                PageNumber = data.PageNumber,
                Items = data.ToList()
            };
            return Ok(new ApiSuccessResult<PagedResult<NotifySystemAdminVm>>(pagedResult));
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateNotifySystemVm model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var x = new NotifySystem()
            {
                Title = model.Title,
                StartTime = model.StartTime,
                EndTime = model.EndTime,
                Url = model.Url,
                UserIdCreated = UserId
            };
            _db.NotifySystems.Add(x);
            await _db.SaveChangesAsync();

            return Ok(new ApiSuccessResult<string>(x.Id.ToString()));
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var x = await _db.NotifySystems.FindAsync(id);
            if (x == null)
            {
                return Ok(new ApiErrorResult<string>("Not found"));
            }
            var result = new NotifySystemAdminVm()
            {
                Id = x.Id,
                Title = x.Title,
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                Url = x.Url,
                CreatedTime = x.CreatedTime
            };
            return Ok(new ApiSuccessResult<NotifySystemAdminVm>(result));
        }
        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(EditNotifySystemVm model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var x = await _db.NotifySystems.FindAsync(model.Id);
            if (x == null)
            {
                return Ok(new ApiErrorResult<string>("Not found"));
            }
            x.Id = model.Id;
            x.Title = model.Title;
            x.StartTime = model.StartTime;
            x.EndTime = model.EndTime;
            x.Url = model.Url;
            await _db.SaveChangesAsync();
            return Ok(new ApiSuccessResult<string>(x.Id.ToString()));
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromForm] int id)
        {
            var item = await _db.NotifySystems.FindAsync(id);
            if (item != null)
            {
                _db.NotifySystems.Remove(item);
                await _db.SaveChangesAsync();
                return Ok(new ApiSuccessResult<string>());
            }
            return Ok(new ApiErrorResult<string>("Not Found!"));
        }
    }
}
