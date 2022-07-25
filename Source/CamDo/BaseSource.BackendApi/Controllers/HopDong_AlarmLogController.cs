using BaseSource.Data.EF;
using BaseSource.Data.Entities;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.HopDong_AlarmLog;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSource.BackendApi.Controllers
{
    public class HopDong_AlarmLogController : BaseApiController
    {
        private readonly BaseSourceDbContext _db;
        public HopDong_AlarmLogController(BaseSourceDbContext db)
        {
            _db = db;
        }
        [HttpGet("GetHopDong_AlarmLog")]
        public async Task<IActionResult> GetHopDong_AlarmLog(int hopDongId)
        {
            var result = await _db.HopDong_AlarmLogs.Where(x => x.HopDongId == hopDongId)
                .Select(x => new HopDong_AlarmLogVm()
                {
                    HopDongId = x.HopDongId,
                    Note = x.Note,
                    CreatedDate = x.CreatedDate,
                    AlarmDate = x.AlarmDate,
                    IsDisable = x.IsDisable
                }).ToListAsync();
            return Ok(new ApiSuccessResult<List<HopDong_AlarmLogVm>>(result));
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateHopDong_AlarmLogVm model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var log = new HopDong_AlarmLog()
            {
                HopDongId = model.HopDongId,
                Note = model.Note,
                UserId = UserId,
                CreatedDate = DateTime.Now,
                AlarmDate = !model.IsDisable ? model.AlarmDate : null,
                IsDisable = model.IsDisable
            };
            _db.HopDong_AlarmLogs.Add(log);
            await _db.SaveChangesAsync();
            var title = model.IsDisable ? "Dừng hẹn giờ thành công" : "Đặt lịch hẹn giờ thành công";
            return Ok(new ApiSuccessResult<string>(title));
        }
    }
}
