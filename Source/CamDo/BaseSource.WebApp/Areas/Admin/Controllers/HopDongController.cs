using BaseSource.ApiIntegration.WebApi.CauHinhHangHoa;
using BaseSource.ApiIntegration.WebApi.HopDong;
using BaseSource.ViewModels.CauHinhHangHoa;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.HopDong;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSource.WebApp.Areas.Admin.Controllers
{
    public class HopDongController : BaseAdminController
    {
        private readonly ICauHinhHangHoaApiClient _cauHinhHangHoaApiClient;
        private readonly IHopDongApiClient _hopDongApiClient;
        public HopDongController(ICauHinhHangHoaApiClient cauHinhHangHoaApiClient, IHopDongApiClient hopDongApiClient)
        {
            _cauHinhHangHoaApiClient = cauHinhHangHoaApiClient;
            _hopDongApiClient = hopDongApiClient;
        }
        public async Task<IActionResult> Create()
        {
            var requestCauHinhHH = new GetCauHinhHangHoaPagingRequest()
            {
                Page = 1,
                PageSize = int.MaxValue
            };
            var resultCuaHinhHH = await _cauHinhHangHoaApiClient.GetPagings(requestCauHinhHH);
            ViewData["ListHangHoa"] = new SelectList(resultCuaHinhHH.ResultObj.Items, "Id", "Ten");
             
            var model = new CreateHopDongVm()
            {
                HD_NgayVay = DateTime.Now.Date
            };

            return PartialView("_Create", model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateHopDongVm model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var result = await _hopDongApiClient.Create(model);
            if (!result.IsSuccessed)
            {
                return Json(new ApiErrorResult<string>(result.ValidationErrors));
            }
            return Json(new ApiSuccessResult<string>());
        }


        public async Task<IActionResult> GetListThuocTinhByTaiSan(int id)
        {
            var result = await _cauHinhHangHoaApiClient.GetById(id);
            if (!result.IsSuccessed)
            {
                return NotFound();
            }
            var model = new List<ThuocTinhHangHoaVm>();
            if (!string.IsNullOrEmpty(result.ResultObj.ListThuocTinh))
            {
                var lstThuocTinh = JsonConvert.DeserializeObject<string[]>(result.ResultObj.ListThuocTinh);
                foreach (var item in lstThuocTinh)
                {
                    model.Add(new ThuocTinhHangHoaVm()
                    {
                        Name = item,
                        Value = "",
                    });
                }
            }
            return Json(model);
        }

    }
}
