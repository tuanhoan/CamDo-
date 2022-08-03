using BaseSource.ApiIntegration.AdminApi.LienHe;
using BaseSource.ViewModels.Admin;
using BaseSource.ViewModels.Common;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BaseSource.AdminApp.Controllers
{
    public class LienHeController : BaseController
    {
        private readonly ILienHeAdminApiClient _apiClient;
        public LienHeController(ILienHeAdminApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var request = new GetLienHePagingRequest_Admin()
            {
                Page = page,
                PageSize = 10,
            };
            var result = await _apiClient.GetPagings(request);
            return View(result.ResultObj);
        }

        public async Task<IActionResult> View(int id)
        {
            var result = await _apiClient.GetById(id);
            if (!result.IsSuccessed)
            {
                return NotFound();
            }
            var model = new LienHeAdminVm()
            {
                Id = result.ResultObj.Id,
                Name = result.ResultObj.Name,
                Phone = result.ResultObj.Phone,
                Email = result.ResultObj.Email,
                IsRead = result.ResultObj.IsRead,
                Message = result.ResultObj.Message,
                CreatedTime = result.ResultObj.CreatedTime,
            };

            return View(model);
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
