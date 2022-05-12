using BaseSource.Data.EF;
using BaseSource.Data.Entities;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.FeedBack;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSource.BackendApi.Controllers
{
    public class FeedBackController : BaseApiController
    {
        private readonly BaseSourceDbContext _db;
        public FeedBackController(BaseSourceDbContext db)
        {
            _db = db;
        }
        [HttpPost("Create")]
       
        public async Task<IActionResult> Create(CreateFeedBackVm model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var userProfile = await _db.UserProfiles.FindAsync(UserId);
            var cuaHang = await _db.CuaHangs.FindAsync(CuaHangId);

            var fb = new FeedBack()
            {
                FeedBackContent = model.Content,
                UserFeedBack = userProfile.FullName,
                CuaHangId = CuaHangId,
                TenCuaHang = cuaHang.Ten,
                UserId = UserId,
                CreatedTime = DateTime.Now
            };

            _db.FeedBacks.Add(fb);
            await _db.SaveChangesAsync();
            return Ok(new ApiSuccessResult<string>("Tạo yêu cầu thành công, chúng tôi sẽ xử lý sớm nhất!"));
        }
    }
}
