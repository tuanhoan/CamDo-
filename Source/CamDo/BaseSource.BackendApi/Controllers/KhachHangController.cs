using BaseSource.Data.EF;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.KhachHang;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSource.BackendApi.Controllers
{
    public class KhachHangController : BaseApiController
    {
        private readonly BaseSourceDbContext _db;
        public KhachHangController(BaseSourceDbContext db)
        {
            _db = db;
        }
        [HttpGet("GetByName")]
        public async Task<IActionResult> GetByName(string info)
        {
            var lst = await _db.KhachHangs.Where(x => x.Ten.Contains(info.Trim())).Select(x => new KhachHangVm()
            {
                Id = x.Id,
                Ten = x.Ten,
                SDT = x.SDT,
                CMND = x.CMND,
                CMND_NgayCap = x.CMND_NgayCap,
                CMND_NoiCap = x.CMND_NoiCap,
                DiaChi = x.DiaChi
            }).ToListAsync();
            return Ok(new ApiSuccessResult<List<KhachHangVm>>(lst));
        }
    }
}
