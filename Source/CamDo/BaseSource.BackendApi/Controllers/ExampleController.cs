using BaseSource.Data.EF;
using BaseSource.ViewModels.Catalog;
using BaseSource.ViewModels.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSource.BackendApi.Controllers
{
    [Route("api/[controller]")]
    public class ExampleController : BaseApiController
    {
        private readonly BaseSourceDbContext _db;

        public ExampleController(BaseSourceDbContext db)
        {
            _db = db;
        }

        //[HttpGet("GetById")]
        //[AllowAnonymous]
        //public async Task<IActionResult> GetById(string id)
        //{
        //    var model = await _db.Example.FindAsync(id);
        //    if (model == null)
        //    {
        //        return Ok(new ApiErrorResult<string>("Not found!"));
        //    }

        //    return Ok(new ApiSuccessResult<ExampleVm>(model));
        //}

        //[HttpGet("GetPagings")]
        //[AllowAnonymous]
        //public async Task<IActionResult> GetPagings([FromQuery] GetExamplePagingRequest request)
        //{
        //    var model = _db.Users.AsQueryable();

        //    if (!string.IsNullOrEmpty(request.ParamExample1))
        //    {
        //        model = model.Where(...)
        //    }
        //    if (!string.IsNullOrEmpty(request.ParamExample2))
        //    {
        //        model = model.Where(...)
        //    }

        //    var data = await model.Select(x => new ExampleVm()
        //    {
        //        Id = x.Id,
        //        Name = x.FirstName,
        //        ...
        //    }).OrderByDescending(x => x.Id).ToPagedListAsync(request.Page, request.PageSize);
        //    var pagedResult = new PagedResult<ExampleVm>()
        //    {
        //        TotalItemCount = data.TotalItemCount,
        //        PageSize = data.PageSize,
        //        PageNumber = data.PageNumber,
        //        Items = data.ToList()
        //    };

        //    return Ok(new ApiSuccessResult<PagedResult<ExampleVm>>(pagedResult));
        //}

        //[HttpPost("Create")]
        //public async Task<IActionResult> Create(CreateExampleVm model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));
        //    }

        //    if (model.Name...) // check condition if required
        //    {
        //        ModelState.AddModelError("Name", "Name is....");
        //        return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));
        //    }

        //    // new object and add to db
        //
        //    await _db.SaveChangesAsync();

        //    return Ok(new ApiSuccessResult<string>());
        //}

        //[HttpPost("Delete")]
        //public async Task<IActionResult> Delete(string id)
        //{
        //    var model = await _db.Example.FindAsync(id);
        //    if (model == null)
        //    {
        //        return Ok(new ApiErrorResult<string>("Not found!"));
        //    }

        //    // delete

        //    await _db.SaveChangesAsync();

        //    return Ok(new ApiSuccessResult<string>());
        //}
    }
}
