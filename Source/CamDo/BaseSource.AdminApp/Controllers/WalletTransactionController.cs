
using BaseSource.ApiIntegration.AdminApi.WalletTransaction;
using BaseSource.ViewModels.Admin;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BaseSource.AdminApp.Controllers
{
    public class WalletTransactionController : Controller
    {
        private readonly IWalletTransactionAdminApiClient _apiClient;
        public WalletTransactionController(IWalletTransactionAdminApiClient apiClient)
        {
            _apiClient = apiClient;
        }
        public async Task<IActionResult> Index(string ten, int page = 1)
        {
            var request = new WalletTransactionPagingRequest_Admin()
            {
                Page = page,
                PageSize = 10,
                Info = ten
            };
            var result = await _apiClient.GetPagings(request);
            return View(result.ResultObj);
        }
    }
}
