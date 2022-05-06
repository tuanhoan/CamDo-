using BaseSource.ApiIntegration.WebApi.MoTaHinhThucLai;
using BaseSource.ViewModels.MoTaHinhThucLai;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSource.WebApp.Areas.Admin.Controllers
{
    public class MoTaHinhThucLaiController : Controller
    {
        private readonly IMoTaHinhThucLaiApiClient _apiClient;
        public MoTaHinhThucLaiController(IMoTaHinhThucLaiApiClient apiClient)
        {
            _apiClient = apiClient;
        }
        public async Task<IActionResult> GetMoTaHinhThucLai(int hinhThucLai)
        {
            var request = new GetMoTaHinhThucLaiPagingRequest()
            {
                Page = 1,
                PageSize = 1,
                HinhThucLai = hinhThucLai
            };
            var result = await _apiClient.GetPagings(request);
            return Json(result.ResultObj.Items);
        }
    }
}
