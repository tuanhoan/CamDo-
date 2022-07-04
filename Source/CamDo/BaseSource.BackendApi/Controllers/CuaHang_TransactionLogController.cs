using BaseSource.Data.EF;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.CuaHang_TransactionLog;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSource.BackendApi.Controllers
{
    public class CuaHang_TransactionLogController : BaseApiController
    {
        private readonly BaseSourceDbContext _db;
        public CuaHang_TransactionLogController(BaseSourceDbContext db)
        {
            _db = db;
        }
        [HttpGet("GetCuaHang_TransactionLogHistory")]
        public async Task<IActionResult> GetCuaHang_TransactionLogHistory(int hopDongId)
        {
            var result = await _db.CuaHang_TransactionLogs.Join(_db.UserProfiles, trans => trans.UserId,
                u => u.UserId, (trans, u) => new CuaHang_TransactionLogVm()
                {
                    Id = trans.Id,
                    FullName = u.FullName,
                    CuaHangId = trans.CuaHangId,
                    HopDongId = trans.HopDongId,
                    ReferId = trans.ReferId,
                    ActionType = trans.ActionType,
                    MoneyDebit = trans.MoneyDebit,
                    MoneyPayNeed = trans.MoneyPayNeed,
                    FromDate = trans.FromDate,
                    ToDate = trans.ToDate,
                    CreatedDate = trans.CreatedDate
                }).Where(x => x.HopDongId == hopDongId).OrderByDescending(x=>x.CreatedDate).ToListAsync();
            return Ok(new ApiSuccessResult<List<CuaHang_TransactionLogVm>>(result));
        }
    }
}
