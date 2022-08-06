using BaseSource.ApiIntegration.WebApi.BaiViet;
using BaseSource.ViewModels.BaiViet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BaseSource.WebApp.Controllers
{
    public class TinhNangController : Controller
    {
        private readonly IBaiVietApiClient _apiClient;

        public TinhNangController(IBaiVietApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index([FromQuery] string url)
        {
            var result = await _apiClient.GetAll();

            var model = new TinhNangPageVm();

            if (result.IsSuccessed)
            {
                model.menus = result.ResultObj;

                if (url != null)
                {
                    var baiVietResult = await _apiClient.GetByUrl(url);

                    if (baiVietResult.IsSuccessed)
                    {
                        model.baiViet = baiVietResult.ResultObj;
                    }
                }

                if (model.baiViet == null && result.ResultObj.Count > 0)
                {
                    var baiVietResult = await _apiClient.GetByUrl(result.ResultObj[0].Url);

                    if (baiVietResult.IsSuccessed)
                    {
                        model.baiViet = baiVietResult.ResultObj;
                    }
                }
            }

            return View(model);
        }
    }
}
