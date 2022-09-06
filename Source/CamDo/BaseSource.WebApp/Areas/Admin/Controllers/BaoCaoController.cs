using BaseSource.ApiIntegration.WebApi.BaoCao;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BaseSource.WebApp.Areas.Admin.Controllers
{
    public class BaoCaoController : BaseAdminController
    {
        private readonly IBaoCaoApiClient _baoCaoApiClient;
        public BaoCaoController(IBaoCaoApiClient baoCaoApiClient)
        {
            _baoCaoApiClient = baoCaoApiClient;
        }

        //Tổng kết giao dịch
        public async Task<IActionResult>  ReportBalance()
        {
            var result = await _baoCaoApiClient.ReportBalance();
            return View(result.ResultObj);
        }
        //Tổng kết lợi nhuận
        public async Task<IActionResult> Profit()
        {
            return View();
        }
        //Chi tiết tiền lãi
        public async Task<IActionResult> ReceiveInterest()
        {
            return View();
        }
        //Báo cáo đang cho vay
        public async Task<IActionResult> ReportPawnHolding()
        {
            return View();
        }
        //Thống kê thu tiền
        public async Task<IActionResult> PaymentHistory()
        {
            return View();
        }
        //Báo cáo hàng chờ thanh lý
        public async Task<IActionResult> WarehouseLiquidation()
        {
            return View();
        }
        //Báo cáo chuộc đồ, đống HD
        public async Task<IActionResult> ReportPawnNewRepurchase()
        {
            return View();
        }
        //Báo cáo thanh lý đồ
        public async Task<IActionResult> ReportPawnNewLiquidation()
        {
            return View();
        }
        //Báo cáo hợp đồng đã xóa
        public async Task<IActionResult> ReportContractCancel()
        {
            return View();
        }
        //Báo cáo tin nhắn
        public async Task<IActionResult> ReportSMS()
        {
            return View();
        }
        //Bàn giao ca
        public async Task<IActionResult> Inventory()
        {
            return View();
        }
        //Dòng tiền theo ngày
        public async Task<IActionResult> MoneyByDay()
        {
            return View();
        }
        //Khách hàng bị báo xấu
        public async Task<IActionResult> ReportCustomer()
        {
            return View();
        }
    }
}
