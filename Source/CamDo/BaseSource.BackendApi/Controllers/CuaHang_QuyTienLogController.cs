using BaseSource.Data.EF;
using BaseSource.Data.Entities;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.CuaHang;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace BaseSource.BackendApi.Controllers
{
    public class CuaHang_QuyTienLogController : BaseApiController
    {

        private readonly BaseSourceDbContext _db;
        private readonly IConfiguration _configuration;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public CuaHang_QuyTienLogController(BaseSourceDbContext db, IConfiguration configuration,
             IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;

        }

        [HttpGet("GetPagings")]
        public async Task<IActionResult> GetPagings([FromBody] PageQuery query)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var model =await (from quy in _db.CuaHang_QuyTienLogs.AsQueryable()
                         join user in _db.UserProfiles.AsQueryable() on quy.UserId equals user.UserId
                         where quy.CuaHangId == CuaHangId
                         select new QuyCuaHangVm()
                         {
                             Id = quy.Id,
                             CreatedDate =  quy.CreatedDate,
                             CreatedBy =  user.FullName,
                             Money= quy.Money,
                             LogType = (byte)quy.LogType,
                             ActionType = quy.ActionType
                         }).OrderByDescending(x => x.CreatedDate).ToPagedListAsync( query.Page , query.PageSize);

            var pagedResult = new PagedResult<QuyCuaHangVm>()
            {
                TotalItemCount = model.TotalItemCount,
                PageSize = model.PageSize,
                PageNumber = model.PageNumber,
                Items = model.ToList()
            };
            return Ok(new ApiSuccessResult<PagedResult<QuyCuaHangVm>>(pagedResult));
        }

        [HttpPost("CreateOrUpdate")]
        public async Task<IActionResult> CreateOrUpdate(CreateQuyCuaHang model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var cuaHang = await _db.CuaHang_QuyTienLogs.FindAsync(model.Id);
            if(cuaHang == null)
            {
                var dataCreate = new CuaHang_QuyTienLog()
                {
                    CuaHangId = CuaHangId,
                    UserId = UserId,
                    CreatedDate = System.DateTime.Now,
                    Note = model.Note,
                    ActionType = model.ActionType,
                    LogType = model.LogType,
                    Money = model.Money,
                };
               await _db.AddAsync(dataCreate);
            }
            else
            {
                cuaHang.Money = model.Money;
                cuaHang.CreatedDate = System.DateTime.Now;
                cuaHang.Note = model.Note;
                cuaHang.ActionType = model.ActionType;
                cuaHang.LogType = model.LogType;
                _db.Update(cuaHang);
            }
            await _db.SaveChangesAsync();
            return Ok(new ApiSuccessResult<string>(cuaHang.Id.ToString()));
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromForm] int id)
        {
            var cuaHang = await _db.CuaHang_QuyTienLogs.FindAsync(id);
            if (cuaHang != null)
            {
                _db.CuaHang_QuyTienLogs.Remove(cuaHang);

                await _db.SaveChangesAsync();
                return Ok(new ApiSuccessResult<string>());
            }
            return Ok(new ApiErrorResult<string>("Not Found!"));
        }
    }
}
