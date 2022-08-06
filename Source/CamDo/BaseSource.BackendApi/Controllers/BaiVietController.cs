using BaseSource.Data.EF;
using BaseSource.ViewModels.BaiViet;
using BaseSource.ViewModels.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSource.BackendApi.Controllers
{
    public class BaiVietController : BaseApiController
    {
        private readonly BaseSourceDbContext _db;
        public BaiVietController(BaseSourceDbContext db)
        {
            _db = db;
        }

        [HttpGet("GetAll")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var model = _db.BaiViets.AsQueryable();

            var data = await model.Select(x => new BaiVietVm()
            {
                Id = x.Id,
                Name = x.Name,
                Url = x.Url,
            }).ToListAsync();

            return base.Ok(new ApiSuccessResult<List<BaiVietVm>>(data));
        }

        [HttpGet("GetByUrl")]
        [AllowAnonymous]
        public IActionResult GetByUrl(string url)
        {
            var x = _db.BaiViets.Where(x => x.Url == url).FirstOrDefault();

            if (x == null)
            {
                return Ok(new ApiErrorResult<string>("Not found"));
            }

            var result = new BaiVietVm()
            {
                Id = x.Id,
                Name = x.Name,
                Content = x.Content,
                Url = x.Url,
            };

            return Ok(new ApiSuccessResult<BaiVietVm>(result));
        }
    }
}
