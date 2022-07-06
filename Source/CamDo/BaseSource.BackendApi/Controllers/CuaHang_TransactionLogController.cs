using BaseSource.Data.EF;
using BaseSource.Shared.Enums;
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
        public async Task<IActionResult> GetCuaHang_TransactionLogHistory(int hopDongId, EHopDong_ActionType actionType = 0)
        {
           
            var model = _db.CuaHang_TransactionLogs.AsQueryable();
            model = model.Where(x => x.HopDongId == hopDongId);
            if (actionType != 0)
            {
                model = model.Where(x => x.ActionType == (byte)actionType);
            }
            var result = await model.Join(_db.UserProfiles, trans => trans.UserId,
                u => u.UserId, (trans, u) => new CuaHang_TransactionLogVm()
                {
                    Id = trans.Id,
                    FullName = u.FullName,
                    CuaHangId = trans.CuaHangId,
                    HopDongId = trans.HopDongId,
                    ReferId = trans.ReferId,
                    ActionType = trans.ActionType,
                    MoneyAdd = trans.MoneyAdd,
                    MoneySub = trans.MoneySub,
                    MoneyDebit = trans.MoneyDebit,
                    MoneyPayNeed = trans.MoneyPayNeed,
                    FromDate = trans.FromDate,
                    ToDate = trans.ToDate,
                    CreatedDate = trans.CreatedDate,
                  
                }).OrderByDescending(x => x.CreatedDate).ToListAsync();
            return Ok(new ApiSuccessResult<List<CuaHang_TransactionLogVm>>(result));
        }
    }
}
