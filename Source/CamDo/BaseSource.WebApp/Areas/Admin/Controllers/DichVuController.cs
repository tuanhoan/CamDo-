using BaseSource.ApiIntegration.WebApi.BaoCao;
using BaseSource.ApiIntegration.WebApi.DichVu;
using BaseSource.ViewModels.BaoHiem;
using BaseSource.ViewModels.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSource.WebApp.Areas.Admin.Controllers
{
    public class DichVuController : BaseAdminController
    {
        private readonly IDichVuClient _dichVuClient;
        public DichVuController(IDichVuClient dichVuClient)
        {
            _dichVuClient = dichVuClient;
        }

        public async Task<IActionResult> Insurance()
        {
            var request = new BaohiemQr()
            {
                FromDate = null,
                ToDate = null,
                Page = 1,
                PageSize = 20,
                Type = 0
            };
            var result = await _dichVuClient.GetPagings(request);
            return View(result.ResultObj.Items);
        }


        public async Task<IActionResult> Pay()
        {
            return View();
        }
        public async Task<IActionResult> MuaBaoHiem()
        {
            var model = new BaoHiemCreate();
            return PartialView("MuaBaoHiem", model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BaoHiemCreate createBaoHiem)
        {

            createBaoHiem.Type = Shared.Enums.ETypeBaoHiem.DangChoMua;
            createBaoHiem.ThoiGianMua = 360;
            createBaoHiem.ImageList = "ádas";
            createBaoHiem.CuaHangId = 1;
            createBaoHiem.UserId = UserId;
            if (!ModelState.IsValid)
            {
                return Json(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
           
            var result = await _dichVuClient.Create(createBaoHiem);
            if (!result.IsSuccessed)
            {
                return Json(new ApiErrorResult<string>(result.ValidationErrors));
            }
            return Json(new ApiSuccessResult<string>(result.ResultObj));
        }
    }
}
