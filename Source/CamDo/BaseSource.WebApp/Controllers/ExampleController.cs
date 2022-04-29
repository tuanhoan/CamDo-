using BaseSource.ApiIntegration.WebApi;
using BaseSource.ViewModels.Catalog;
using BaseSource.ViewModels.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSource.WebApp.Controllers
{
    public class ExampleController : BaseController
    {
        private readonly IExampleApiClient _exampleApiClient;

        public ExampleController(IExampleApiClient exampleApiClient)
        {
            _exampleApiClient = exampleApiClient;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(string param1, string param2, int page = 1)
        {
            var request = new GetExamplePagingRequest()
            {
                ParamExample1 = param1,
                ParamExample2 = param2,
                Page = page,
                PageSize = 20
            };

            var result = await _exampleApiClient.GetPagings(request);
            if (!result.IsSuccessed)
            {
                return NotFound();
            }

            return View(result.ResultObj);
        }

        public async Task<IActionResult> Details(string id)
        {
            var result = await _exampleApiClient.GetById(id);
            if (!result.IsSuccessed)
            {
                return NotFound();
            }

            return View(result.ResultObj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateExampleVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _exampleApiClient.Create(model);
            if (!result.IsSuccessed)
            {
                ModelState.AddListErrors(result.ValidationErrors);
                return View(model);
            }

            return RedirectToAction("Index");
        }

        //// if using ajax
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(CreateExampleVm model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Json(new ApiErrorResult<string>(ModelState.GetListErrors()));
        //    }

        //    var result = await _exampleApiClient.Create(model);
        //    if (!result.IsSuccessed)
        //    {
        //        return Json(new ApiErrorResult<string>(result.ValidationErrors));
        //    }

        //    return Json(new ApiSuccessResult<string>());
        //}

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _exampleApiClient.Delete(id);
            if (!result.IsSuccessed)
            {
                return Json(new ApiErrorResult<string>(result.Message));
            }

            return Json(new ApiSuccessResult<string>());
        }
    }
}
