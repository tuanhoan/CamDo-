using BaseSource.Data.EF;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.GoiSanPham;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSource.BackendApi.Controllers
{
    public class GoiSanPhamController : BaseApiController
    {
        private readonly BaseSourceDbContext _db;

        public GoiSanPhamController(BaseSourceDbContext db)
        {
            _db = db;
        }

        [HttpGet("GetAll")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var model = _db.GoiSanPhams.AsQueryable();

            var data = await model.Select(x => new GoiSanPhamVm()
            {
                Id = x.Id,
                Ten = x.Ten,
                TongTien = x.TongTien,
                KhuyenMai = x.KhuyenMai,
            }).ToListAsync();

            return Ok(new ApiSuccessResult<List<GoiSanPhamVm>>(data));
        }
    }
}
