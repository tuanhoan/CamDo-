using BaseSource.Data.EF;
using BaseSource.Data.Entities;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.LienHe;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BaseSource.BackendApi.Controllers
{
    public class LienHeController : BaseApiController
    {
        private readonly BaseSourceDbContext _db;
        public LienHeController(BaseSourceDbContext db)
        {
            _db = db;
        }

        [AllowAnonymous]
        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateLienHeVm model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }

            var record = new LienHe()
            {
                Name = model.Name,
                Email = model.Email,
                Phone = model.Phone,
                Message = model.Message,
                CreatedTime = DateTime.Now,
                IsRead  = false
            };

            _db.LienHes.Add(record);
            await _db.SaveChangesAsync();
            return Ok(new ApiSuccessResult<string>("Tạo liên hệ thành công, chúng tôi sẽ xử lý sớm nhất!"));
        }
    }
}
