using BaseSource.ApiIntegration.WebApi.QuanlyThuChi;
using BaseSource.ViewModels.Admin.ThuChi;
using BaseSource.ViewModels.Common;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSource.WebApp.Areas.Admin.Controllers
{
    public class QuanLyThuChiController : BaseAdminController
    {
        private readonly IQuanLyThuChiApiClient _quanLyThuChiApiClient;
        public QuanLyThuChiController(IQuanLyThuChiApiClient quanLyThuChiApiClient)
        {
            _quanLyThuChiApiClient = quanLyThuChiApiClient;
        }
        #region Chi Hoạt Động
        public async Task<IActionResult> Expense()
        {
            var data = await _quanLyThuChiApiClient.GetAllExpensesAsync(new GetChiHoatDongPagingRequest
            {
                Page = 1,
                PageSize = 10,
                ShopId = ShopId,
            });

            ViewBag.Incomes = data.ResultObj;
            return View();

        }

        public async Task<IActionResult> PageFilterExpense(GetChiHoatDongPagingRequest model)
        {
            model.Page = model.Page < 1 ? 1 : model.Page;
            model.PageSize = 10;

            model.ShopId = ShopId;
            var result = await _quanLyThuChiApiClient.GetAllExpensesAsync(model);
            return PartialView("_PageExpense", result.ResultObj);
        }

        [HttpPost]
        public async Task<IActionResult> CreateExpense(CreateChiHoatDongVm model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            model.ShopId = ShopId;
            var result = await _quanLyThuChiApiClient.CreateExpenseAsync(model);
            if (!result.IsSuccessed)
            {
                return Json(new ApiErrorResult<string>(result.ValidationErrors));
            }
            return Json(new ApiSuccessResult<string>(Url.Action("Expense"), "Tạo mới phiếu chi thành công!"));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteExpense(long id)
        {
            if (id < 1)
            {
                return RedirectToAction("Expense");
            }

            await _quanLyThuChiApiClient.DeleteExpenseAsync(id);
            return RedirectToAction("Expense");
        }

        [HttpPost]
        public async Task<IActionResult> PrintExpense(ExportExpenseTemplateVm model)
        {
            //set default value
            model.ShopName = ShopName;
            model.UserPrint = UserName;
            model.Hotline = "123456789";

            return PartialView("_TemplateExportExpense", model);
        }
        #endregion

        #region Thu Hoạt Động
        public async Task<IActionResult> Income()
        {

            var data = await _quanLyThuChiApiClient.GetAllIncomesAsync(new GetThuHoatDongPagingRequest
            {
                Page = 1,
                PageSize = 10,
                ShopId = ShopId,
            });

            ViewBag.Incomes = data.ResultObj;
            return View();
        }

        public async Task<IActionResult> PageFilterIncome(GetThuHoatDongPagingRequest model)
        {
            model.Page = model.Page < 1 ? 1 : model.Page;
            model.PageSize = 10;

            model.ShopId = ShopId;
            var result = await _quanLyThuChiApiClient.GetAllIncomesAsync(model);
            return PartialView("_PageIncome", result.ResultObj);
        }


        [HttpPost]
        public async Task<IActionResult> CreateIncome(CreateThuHoatDongVm model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            model.ShopId = ShopId;
            var result = await _quanLyThuChiApiClient.CreateIncomeAsync(model);
            if (!result.IsSuccessed)
            {
                return Json(new ApiErrorResult<string>(result.ValidationErrors));
            }
            return Json(new ApiSuccessResult<string>(Url.Action("Income"), "Tạo mới phiếu thu thành công!"));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteInCome(long id)
        {
            if (id < 1)
            {
                return RedirectToAction("Income");
            }

            var result = await _quanLyThuChiApiClient.DeleteInComeAsync(id);
            return RedirectToAction("Income");
        }

        [HttpPost]
        public async Task<IActionResult> PrintInCome(ExportIncomeTemplateVm model)
        {
            model.Number = model.Id.ToString();
            //set default value
            model.ShopName = ShopName;

            return PartialView("_TemplateExportIncome", model);
        }
        #endregion

    }
}
