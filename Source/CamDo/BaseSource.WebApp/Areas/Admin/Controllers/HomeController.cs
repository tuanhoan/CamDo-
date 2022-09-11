using BaseSource.ApiIntegration.WebApi.CuaHang;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSource.WebApp.Areas.Admin.Controllers
{
    public class HomeController : BaseAdminController
    {
        private readonly ICuaHangApiClient _cuaHangApiClient;

        public HomeController(ICuaHangApiClient cuaHangApiClient)
        {
            _cuaHangApiClient = cuaHangApiClient;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _cuaHangApiClient.GetDashBoard(ShopId);
            return View(result.ResultObj);
        }
    }
}
