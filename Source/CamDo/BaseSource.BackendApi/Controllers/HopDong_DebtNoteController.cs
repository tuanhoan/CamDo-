using BaseSource.Data.EF;
using BaseSource.Data.Entities;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.HopDong_DebtNote;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSource.BackendApi.Controllers
{

    public class HopDong_DebtNoteController : BaseApiController
    {
        private readonly BaseSourceDbContext _db;
        public HopDong_DebtNoteController(BaseSourceDbContext db)
        {
            _db = db;
        }
        [HttpGet("GetHopDong_DebtNote")]
        public async Task<IActionResult> GetHopDong_DebtNote(int hopDongId)
        {
            var result = await _db.HopDong_DebtNotes.Join(_db.UserProfiles, note => note.UserId, u => u.UserId, (note, u) => new HopDong_DebtNoteVm()
            {
                HopDongId = note.HopDongId,
                Note = note.Note,
                CreatedDate = note.CreatedDate,
                FullName = u.FullName
            }).Where(x => x.HopDongId == hopDongId).OrderByDescending(x => x.CreatedDate).ToListAsync();
            return Ok(new ApiSuccessResult<List<HopDong_DebtNoteVm>>(result));
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateHopDong_DebtNoteVm model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var note = new HopDong_DebtNote()
            {
                HopDongId = model.HopDongId,
                Note = model.Note,
                UserId = UserId,
                CreatedDate = DateTime.Now
            };
            _db.HopDong_DebtNotes.Add(note);
            await _db.SaveChangesAsync();
            return Ok(new ApiSuccessResult<string>(null, "Tạo nhắc nhở thành công"));
        }
    }
}
