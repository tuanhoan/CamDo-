using BaseSource.ApiIntegration.AdminApi.WalletTransaction;
using BaseSource.ViewModels.Admin;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BaseSource.AdminApp.Controllers
{
    public class LichSuMuaSanPhamController : BaseController
    {
        private readonly IGoiSanPham_LichSuMuaAdminApiClient _apiClient;
        public LichSuMuaSanPhamController(IGoiSanPham_LichSuMuaAdminApiClient apiClient)
        {
            _apiClient = apiClient;
        }
        public async Task<IActionResult> Index(string ten, int page = 1)
        {
            var request = new GoiSanPham_LichSuMuaQr()
            {
                Page = page,
                PageSize = 10,
                Info = ten
            };
            var result = await _apiClient.GetPagings(request);
            return View(result);
        }
    }
}
