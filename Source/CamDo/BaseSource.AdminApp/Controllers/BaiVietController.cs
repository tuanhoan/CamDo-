using BaseSource.ApiIntegration.AdminApi.BaiViet;
using BaseSource.ApiIntegration.AdminApi.DanhMucBaiViet;
using BaseSource.ViewModels.Admin;
using BaseSource.ViewModels.Common;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BaseSource.AdminApp.Controllers
{
    public class BaiVietController : BaseController
    {
        private readonly IBaiVietAdminApiClient _apiClient;
        private readonly IDanhMucBaiVietAdminApiClient _danhMucBaiVietAdminApiClient;
        public BaiVietController(IBaiVietAdminApiClient apiClient, IDanhMucBaiVietAdminApiClient danhMucBaiVietAdminApiClient)
        {
            _apiClient = apiClient;
            _danhMucBaiVietAdminApiClient = danhMucBaiVietAdminApiClient;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var request = new GetBaiVietPagingRequest_Admin()
            {
                Page = page,
                PageSize = 10,
            };
            var result = await _apiClient.GetPagings(request);
            return View(result.ResultObj);
        }

        public async Task<IActionResult> Create()
        {
            var result = await _danhMucBaiVietAdminApiClient.GetAll();

            var model = new CreateBaiVietAdminVm()
            {
                DanhMucSelect = result.ResultObj
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBaiVietAdminVm model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var result = await _apiClient.Create(model);
            if (!result.IsSuccessed)
            {
                return Json(new ApiErrorResult<string>(result.ValidationErrors));
            }
            return Json(new ApiSuccessResult<string>(Url.Action("Index")));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var task1 = _apiClient.GetById(id);
            var task2 = _danhMucBaiVietAdminApiClient.GetAll();

            await Task.WhenAll(task1, task2);

            if (!task1.Result.IsSuccessed && !task2.Result.IsSuccessed)
            {
                return NotFound();
            }
            var model = new EditBaiVietAdminVm()
            {
                Id = task1.Result.ResultObj.Id,
                Name = task1.Result.ResultObj.Name,
                Content = task1.Result.ResultObj.Content,
                DanhMucBaiVietId = task1.Result.ResultObj.DanhMucBaiViet.Id,
                Url = task1.Result.ResultObj.Url,
                DanhMucSelect = task2.Result.ResultObj,
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditBaiVietAdminVm model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var result = await _apiClient.Edit(model);
            if (!result.IsSuccessed)
            {
                return Json(new ApiErrorResult<string>(result.ValidationErrors));
            }
            return Json(new ApiSuccessResult<string>(Url.Action("Index")));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _apiClient.Delete(id);
            if (result.IsSuccessed)
            {
                return Json(new ApiSuccessResult<string>());
            }
            return Json(new ApiErrorResult<string>(result.Message));
        }
    }
}
