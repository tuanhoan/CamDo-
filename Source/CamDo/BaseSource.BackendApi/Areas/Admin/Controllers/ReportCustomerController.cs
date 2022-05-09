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
    public class ReportCustomerController : BaseAdminApiController
    {
        private readonly BaseSourceDbContext _db;
        public ReportCustomerController(BaseSourceDbContext db)
        {
            _db = db;
        }
        [HttpGet("GetPagings")]
        public async Task<IActionResult> GetPagings([FromQuery] GetReportCustomerPagingRequest_Admin request)
        {
            var model = _db.ReportCustomers.AsQueryable();

            if (!string.IsNullOrEmpty(request.Info))
            {
                model = model.Where(x => x.PhoneNumber.Contains(request.Info) || x.CMND.Contains(request.Info) || x.CustomerName.Contains(request.Info));
            }

            var data = await model.Select(x => new ReportCustomerAdminVm()
            {
                Id = x.Id,
                CustomerName = x.CustomerName,
                PhoneNumber = x.PhoneNumber,
                CMND = x.CMND,
                Address = x.Address,
                Reason = x.Reason,
                UserReport = x.UserReport,
                TenCuaHang = x.TenCuaHang
            }).OrderByDescending(x => x.Id).ToPagedListAsync(request.Page, request.PageSize);

            var pagedResult = new PagedResult<ReportCustomerAdminVm>()
            {
                TotalItemCount = data.TotalItemCount,
                PageSize = data.PageSize,
                PageNumber = data.PageNumber,
                Items = data.ToList()
            };
            return Ok(new ApiSuccessResult<PagedResult<ReportCustomerAdminVm>>(pagedResult));
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var x = await _db.ReportCustomers.FindAsync(id);
            if (x == null)
            {
                return Ok(new ApiErrorResult<string>("Not found"));
            }
            var result = new ReportCustomerAdminVm()
            {
                Id = x.Id,
                CustomerName = x.CustomerName,
                PhoneNumber = x.PhoneNumber,
                CMND = x.CMND,
                Address = x.Address,
                Reason = x.Reason,
            };
            return Ok(new ApiSuccessResult<ReportCustomerAdminVm>(result));
        }
        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(EditRportCustomerAdminVm model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var x = await _db.ReportCustomers.FindAsync(model.Id);
            if (x == null)
            {
                return Ok(new ApiErrorResult<string>("Not found"));
            }
            x.CustomerName = model.CustomerName;
            x.PhoneNumber = model.PhoneNumber;
            x.CMND = model.CMND;
            x.Address = model.Address;
            x.Reason = model.Reason;
            x.UpdatedTime = DateTime.Now;
            x.UpdateById = UserId.ToString();
            await _db.SaveChangesAsync();
            return Ok(new ApiSuccessResult<string>(x.Id.ToString()));
        }
    }
}
