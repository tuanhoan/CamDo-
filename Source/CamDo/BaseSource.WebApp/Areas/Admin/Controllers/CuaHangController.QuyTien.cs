using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.CuaHang;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BaseSource.WebApp.Areas.Admin.Controllers
{

    public partial class CuaHangController : BaseAdminController
    {
        
        #region MoneyNewDate
        public IActionResult MoneyNewDate()
        {
            
            return View();
        }

        public async Task<IActionResult> CreateQuyDauNgay(CreateQuyCuaHang model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var result = await _cuaHangApiClient.CreateOrUpdate(model);
            if (!result.IsSuccessed)
            {
                return Json(new ApiErrorResult<string>(result.ValidationErrors));
            }
            return Json(1);
        }
        public async Task<IActionResult> CreateTienDauNgay(CreateQuyCuaHang model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var result = await _cuaHangApiClient.CreateOrUpdate(model);
            if (!result.IsSuccessed)
            {
                return Json(new ApiErrorResult<string>(result.ValidationErrors));
            }
            return Json(1);
        }
        public async Task<IActionResult> GetData(int page = 1)
        {
            var request = new PageQuery()
            {
                Page = page,
                PageSize = 10,
            };
            var result = await _cuaHangApiClient.GetPagings(request);
            return PartialView("_HistoryQuyTiens", result.ResultObj);
        }


        public async Task<IActionResult> GetDataThongKe()
        {
            var result = await _cuaHangApiClient.GetDataThongKe();
            return PartialView("_ThongKe", result.ResultObj);
        }
        #endregion
    }
}
