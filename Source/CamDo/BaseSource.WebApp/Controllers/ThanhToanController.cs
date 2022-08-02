using BaseSource.ApiIntegration.WebApi.GoiSanPham;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BaseSource.WebApp.Controllers
{
    public class ThanhToanController : Controller
    {
        private readonly IGoiSanPhamApiClient _apiClient;

        public ThanhToanController(IGoiSanPhamApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _apiClient.GetAll();

            if (!result.IsSuccessed)
            {
                return NotFound();
            }

            return View(result.ResultObj);
        }
    }
}
