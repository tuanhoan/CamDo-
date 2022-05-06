using BaseSource.Data.EF;
using BaseSource.Shared.Enums;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.MoTaHinhThucLai;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace BaseSource.BackendApi.Controllers
{
    public class MoTaHinhThucLaiController : BaseApiController
    {
        private readonly BaseSourceDbContext _db;
        public MoTaHinhThucLaiController(BaseSourceDbContext db)
        {
            _db = db;
        }
        [HttpGet("GetPagings")]
        public async Task<IActionResult> GetPagings([FromQuery] GetMoTaHinhThucLaiPagingRequest request)
        {
            var model = _db.MoTaHinhThucLais.AsQueryable();

            if (request.HinhThucLai != 0)
            {
                var lai = (EHinhThucLai)request.HinhThucLai;
                model = model.Where(x => x.HinhThucLai == lai);
            }

            var data = await model.Select(x => new MoTaHinhThucLaiVm()
            {
                Id = x.Id,
                HinhThucLai = x.HinhThucLai,
                MoTaKyLai = x.MoTaKyLai,
                TyLeLai = x.TyLeLai
            }).OrderByDescending(x => x.Id).ToPagedListAsync(request.Page, request.PageSize);

            var pagedResult = new PagedResult<MoTaHinhThucLaiVm>()
            {
                TotalItemCount = data.TotalItemCount,
                PageSize = data.PageSize,
                PageNumber = data.PageNumber,
                Items = data.ToList()
            };
            return Ok(new ApiSuccessResult<PagedResult<MoTaHinhThucLaiVm>>(pagedResult));
        }
    }
}
