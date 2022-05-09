using BaseSource.ApiIntegration.AdminApi.FeedBack;
using BaseSource.ViewModels.Admin;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSource.AdminApp.Controllers
{
    public class FeedBackController : BaseController
    {
        private readonly IFeedBackAdminApiClient _apiClient;
        public FeedBackController(IFeedBackAdminApiClient apiClient)
        {
            _apiClient = apiClient;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            var request = new GetFeedBackPagingRequest_Admin()
            {
                Page = page,
                PageSize = 10,
            };
            var result = await _apiClient.GetPagings(request);
            return View(result.ResultObj);
        }
    }
}
