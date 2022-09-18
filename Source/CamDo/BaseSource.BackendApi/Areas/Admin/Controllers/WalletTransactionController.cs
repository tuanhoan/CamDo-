using BaseSource.Data.EF;
using BaseSource.Data.Entities;
using BaseSource.Shared.Enums;
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
    public class WalletTransactionController : BaseAdminApiController
    {
        private readonly BaseSourceDbContext _db;
        public WalletTransactionController(BaseSourceDbContext db)
        {
            _db = db;
        }
        [HttpGet("GetPagings")]
        public async Task<IActionResult> GetPagings([FromQuery] GetGoiSanPhamPagingRequest_Admin request)
        {
            var model = _db.WalletTransactions
                .Include(x => x.UserProfile)
                .AsQueryable();
                


            if (!string.IsNullOrEmpty(request.Info))
            {
                //model = model.Where(x => x.Ten.Contains(request.Info));
            }

            var data = await model.Select(x => new WalletTransactionVM()
            {
                NameUser = x.UserProfile.FullName,
                TargetType = x.TargetType.GetDisplayName(),
                SoBaoHiem = x.TargetId,
                Sotien = x.Amount,
                NhanVienGiaoDich = x.CreatedBy,
                NgayGiaoDich = x.CreatedDate
            }).OrderByDescending(x => x.NgayGiaoDich).ToPagedListAsync(request.Page, request.PageSize);

            var pagedResult = new PagedResult<WalletTransactionVM>()
            {
                TotalItemCount = data.TotalItemCount,
                PageSize = data.PageSize,
                PageNumber = data.PageNumber,
                Items = data.ToList()
            };
            return Ok(new ApiSuccessResult<PagedResult<WalletTransactionVM>>(pagedResult));
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var x = await _db.WalletTransactions.FindAsync(id);
            if (x == null)
            {
                return Ok(new ApiErrorResult<string>("Not found"));
            }
            var result = new WalletTransactionVM()
            {
                NameUser = x.UserProfile.FullName,
                TargetType = x.TargetType.GetDisplayName(),
                SoBaoHiem = x.TargetId,
                Sotien = x.Amount,
                NhanVienGiaoDich = x.CreatedBy,
                NgayGiaoDich = x.CreatedDate
            };
            return Ok(new ApiSuccessResult<WalletTransactionVM>(result));
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(WalletTransactionCreate model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var x = await _db.UserProfiles.FindAsync(model.UserId);

            var sp = new WalletTransaction()
            {
                UserId = model.UserId,
                BalanceBefore = x.Balance,
                BalanceAffter = x.Balance +model.Sotien,
                Amount = model.Sotien,
                CreatedBy = UserId,
                CreatedDate = model.NgayGiaoDich,
                TargetType = model.TargetType,
                TargetId = model.SoBaoHiem,
                Note = model.Note
            };

            _db.WalletTransactions.Add(sp);
            await _db.SaveChangesAsync();
            return Ok(new ApiSuccessResult<string>(sp.Id.ToString()));
        }
        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(WalletTransactionEdit model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var x = await _db.WalletTransactions.FindAsync(model.Id);
            if (x == null)
            {
                return Ok(new ApiErrorResult<string>("Not found"));
            }
            x.BalanceBefore = x.BalanceBefore;
            x.BalanceAffter = x.BalanceBefore + model.Sotien;
            x.Amount        = model.Sotien;
            x.CreatedBy     = UserId;
            x.CreatedDate   = model.NgayGiaoDich;
            x.TargetType    = model.TargetType;
            x.TargetId      = model.SoBaoHiem;
            x.Note = model.Note;
            await _db.SaveChangesAsync();

            return Ok(new ApiSuccessResult<string>(x.Id.ToString()));
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromForm] int id)
        {
            var sp = await _db.WalletTransactions.FindAsync(id);
            if (sp != null)
            {
                _db.WalletTransactions.Remove(sp);
                await _db.SaveChangesAsync();
                return Ok(new ApiSuccessResult<string>());
            }
            return Ok(new ApiErrorResult<string>("Not Found!"));
        }
    }
}
