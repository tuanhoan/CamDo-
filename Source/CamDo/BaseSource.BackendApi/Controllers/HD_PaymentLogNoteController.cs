using BaseSource.Data.EF;
using BaseSource.Data.Entities;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.HD_PaymentLogNote;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSource.BackendApi.Controllers
{
    public class HD_PaymentLogNoteController : BaseApiController
    {
        private readonly BaseSourceDbContext _db;
        public HD_PaymentLogNoteController(BaseSourceDbContext db)
        {
            _db = db;
        }
        [HttpGet("GetPaymentLogNoteByPayment")]
        public async Task<IActionResult> GetPaymentLogNoteByPayment(long paymentId)
        {
            var lstNote = await (from note in _db.HopDong_PaymentLogNotes
                                 join u in _db.Users on note.UserId equals u.Id
                                 where note.PaymentId == paymentId
                                 select new HD_PaymentLogNoteVm()
                                 {
                                     Id = note.Id,
                                     PaymentId = note.PaymentId,
                                     Note = note.Note,
                                     CreatedDate = note.CreatedDate,
                                     UserCreate = u.UserName
                                 }).OrderByDescending(x => x.CreatedDate).Take(3).ToListAsync();

            return Ok(new ApiSuccessResult<List<HD_PaymentLogNoteVm>>(lstNote));
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreatePaymentLogNoteVm model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var note = new HopDong_PaymentLogNote()
            {
                PaymentId = model.PaymentId,
                Note = model.Note,
                UserId = UserId
            };
            _db.HopDong_PaymentLogNotes.Add(note);
            await _db.SaveChangesAsync();
            return Ok(new ApiSuccessResult<string>("Ghi chú thành công"));
        }
    }
}
