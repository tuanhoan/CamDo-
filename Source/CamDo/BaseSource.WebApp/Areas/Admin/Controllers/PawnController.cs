using BaseSource.ApiIntegration.WebApi.HopDong;
using BaseSource.Shared.Enums;
using BaseSource.ViewModels.HopDong;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSource.WebApp.Areas.Admin.Controllers
{
    public class PawnController : BaseAdminController
    {
        private readonly IHopDongApiClient _hopDongApiClient;
        public PawnController(IHopDongApiClient hopDongApiClient)
        {
            _hopDongApiClient = hopDongApiClient;
        }
        public async Task<IActionResult> Index(string info, int page = 1)
        {
            var request = new GetHopDongPagingRequest()
            {
                Page = 1,
                PageSize = 10,
                LoaiHopDong = ELoaiHopDong.Camdo
            };
            var result = await _hopDongApiClient.GetPagings(request);
            return View(result.ResultObj);
        }

    }
}
