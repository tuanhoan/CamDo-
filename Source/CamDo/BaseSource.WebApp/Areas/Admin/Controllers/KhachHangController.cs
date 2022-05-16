using BaseSource.ApiIntegration.WebApi.KhachHang;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.KhachHang;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSource.WebApp.Areas.Admin.Controllers
{
    public class KhachHangController : BaseAdminController
    {
        private readonly IKhachHangApiClient _apiClient;
        public KhachHangController(IKhachHangApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IActionResult> GetByName(string info)
        {
            var result = await _apiClient.GetByName(info);
            return Json(result.ResultObj);
        }
    }
}
