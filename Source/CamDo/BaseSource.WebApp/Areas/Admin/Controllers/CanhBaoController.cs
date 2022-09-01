using BaseSource.ApiIntegration.WebApi.HopDong_AlarmLog;
using BaseSource.Shared.Enums;
using BaseSource.ViewModels.HopDong_AlarmLog;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BaseSource.WebApp.Areas.Admin.Controllers
{
    public class CanhBaoController : BaseAdminController
    {
        private readonly IHopDong_AlarmLog _apiClient;
        public CanhBaoController(IHopDong_AlarmLog apiClient)
        {
            _apiClient = apiClient;
        }
        //Thông báo hẹn giờ
        public async Task<IActionResult> AlarmDate(ELoaiHopDong type , int page = 1)
        {
            var request = new HopDong_AlarmLogRQ()
            {
                Page = page,
                PageSize = 10,
                Type = type,      };
            var result =await _apiClient.GetPagings(request);
            return View( result.ResultObj);
        }
        //Cảnh báo góp vốn
        public IActionResult Capital()
        {
            return View();
        }
        //Cảnh báo cầm đồ
        public IActionResult Pawn()
        {
            return View();
        }
        //Cảnh báo vay lãi
        public IActionResult Loan()
        {
            return View();
        }
        //Cảnh báo vay họ
        public IActionResult Installment()
        {
            return View();
        }
    }
}
