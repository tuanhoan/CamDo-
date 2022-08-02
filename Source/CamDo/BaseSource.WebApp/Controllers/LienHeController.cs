using BaseSource.ApiIntegration.WebApi.LienHe;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.LienHe;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BaseSource.WebApp.Controllers
{
    public class LienHeController : Controller
    {
        private readonly ILienHeApiClient _apiClient;

        public LienHeController(ILienHeApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(CreateLienHeVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _apiClient.Create(model);

            if (!result.IsSuccessed)
            {
                if (result.ValidationErrors != null)
                {
                    ModelState.AddListErrors(result.ValidationErrors);
                    return View(model);
                }
            }
            return View("Success");
        }
    }
}
