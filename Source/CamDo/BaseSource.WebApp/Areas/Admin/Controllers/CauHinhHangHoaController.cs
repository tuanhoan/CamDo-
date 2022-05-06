using BaseSource.ApiIntegration.AdminApi.CauHinhHangHoa;
using BaseSource.ApiIntegration.WebApi.CauHinhHangHoa;
using BaseSource.ViewModels.Admin;
using BaseSource.ViewModels.CauHinhHangHoa;
using BaseSource.ViewModels.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSource.WebApp.Areas.Admin.Controllers
{
    public class CauHinhHangHoaController : BaseAdminController
    {
        private readonly ICauHinhHangHoaApiClient _apiClient;
        public CauHinhHangHoaController(ICauHinhHangHoaApiClient apiClient)
        {
            _apiClient = apiClient;
        }
        public async Task<IActionResult> Index(string ten, int linhvuc, int? status, int page = 1)
        {
            var request = new GetCauHinhHangHoaPagingRequest()
            {
                Page = page,
                PageSize = 10,
                Ten = ten,
                LinhVuc = linhvuc,
                Status = status
            };
            var result = await _apiClient.GetPagings(request);
            return View(result.ResultObj);
        }
        public IActionResult Create()
        {
            var model = new CreateCauHinhHangHoaVm()
            {
                SoTienCam = 10000000,
                Lai = 3,
                KyLai = 15,
                SoNgayQuaHan = 10,
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCauHinhHangHoaVm model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var result = await _apiClient.Create(model);
            if (!result.IsSuccessed)
            {
                return Json(new ApiErrorResult<string>(result.ValidationErrors));
            }
            return Json(new ApiSuccessResult<string>(Url.Action("Index")));
        }
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _apiClient.GetById(id);
            if (!result.IsSuccessed)
            {
                return NotFound();
            }
            var model = new EditCauHinhHangHoaVm()
            {
                Id = result.ResultObj.Id,
                LinhVuc = result.ResultObj.LinhVuc,
                MaTS = result.ResultObj.MaTS,
                Ten = result.ResultObj.Ten,
                IsPublish = result.ResultObj.IsPublish,
                HinhThucLai = result.ResultObj.HinhThucLai,
                IsThuLaiTruoc = result.ResultObj.IsThuLaiTruoc,
                SoTienCam = result.ResultObj.SoTienCam,
                Lai = result.ResultObj.Lai,
                KyLai = result.ResultObj.KyLai,
                SoNgayVay = result.ResultObj.SoNgayVay,
                SoNgayQuaHan = result.ResultObj.SoNgayQuaHan,
                ListThuocTinh = result.ResultObj.ListThuocTinh,
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditCauHinhHangHoaVm model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var result = await _apiClient.Edit(model);
            if (!result.IsSuccessed)
            {
                return Json(new ApiErrorResult<string>(result.ValidationErrors));
            }
            return Json(new ApiSuccessResult<string>(Url.Action("Index")));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _apiClient.Delete(id);
            if (result.IsSuccessed)
            {
                return Json(new ApiSuccessResult<string>());
            }
            return Json(new ApiErrorResult<string>(result.Message));
        }
    }
}
