using BaseSource.ApiIntegration.AdminApi.CauHinhHangHoa;
using BaseSource.ViewModels.Admin;
using BaseSource.ViewModels.Common;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSource.AdminApp.Controllers
{
    public class CauHinhHangHoaController : BaseController
    {
        private readonly ICauHinhHangHoaAdminApiClient _cauHinhHangHoaAdminApiClient;
        public CauHinhHangHoaController(ICauHinhHangHoaAdminApiClient cauHinhHangHoaAdminApiClient)
        {
            _cauHinhHangHoaAdminApiClient = cauHinhHangHoaAdminApiClient;
        }
        public async Task<IActionResult> Index(string ten, int linhvuc, int? status, int page = 1)
        {
            var request = new GetCauHinhHangHoaPagingRequest_Admin()
            {
                Page = page,
                PageSize = 10,
                Ten = ten,
                LinhVuc = linhvuc,
                Status = status
            };
            var result = await _cauHinhHangHoaAdminApiClient.GetPagings(request);
            return View(result.ResultObj);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCauHinhHangHoaAdminVm model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var result = await _cauHinhHangHoaAdminApiClient.Create(model);
            if (!result.IsSuccessed)
            {
                return Json(new ApiErrorResult<string>(result.ValidationErrors));
            }
            return Json(new ApiSuccessResult<string>(Url.Action("Index")));
        }
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _cauHinhHangHoaAdminApiClient.GetById(id);
            if (!result.IsSuccessed)
            {
                return NotFound();
            }
            var model = new EditCauHinhHangHoaAdminVm()
            {
                Id = result.ResultObj.Id,
                LinhVuc = result.ResultObj.LinhVuc,
                MaTS = result.ResultObj.MaTS,
                Ten = result.ResultObj.Ten,
                IsPublish = result.ResultObj.IsPublish,
                HinhThucLai = result.ResultObj.HinhThucLai,
                IsThuLaiTruoc = result.ResultObj.IsThuLaiTruoc,
                TongTien = result.ResultObj.TongTien,
                LaiSuat = result.ResultObj.LaiSuat,
                KyLai = result.ResultObj.KyLai,
                TongThoiGianVay = result.ResultObj.TongThoiGianVay,
                SoNgayQuaHan = result.ResultObj.SoNgayQuaHan,
                ListThuocTinh = result.ResultObj.ListThuocTinh,
                
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditCauHinhHangHoaAdminVm model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var result = await _cauHinhHangHoaAdminApiClient.Edit(model);
            if (!result.IsSuccessed)
            {
                return Json(new ApiErrorResult<string>(result.ValidationErrors));
            }
            return Json(new ApiSuccessResult<string>(Url.Action("Index")));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _cauHinhHangHoaAdminApiClient.Delete(id);
            if (result.IsSuccessed)
            {
                return Json(new ApiSuccessResult<string>());
            }
            return Json(new ApiErrorResult<string>(result.Message));
        }
    }
}
