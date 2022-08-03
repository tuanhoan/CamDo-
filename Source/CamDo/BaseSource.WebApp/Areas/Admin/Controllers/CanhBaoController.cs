using Microsoft.AspNetCore.Mvc;
namespace BaseSource.WebApp.Areas.Admin.Controllers
{
    public class CanhBaoController : BaseAdminController
    {
        //Thông báo hẹn giờ
        public IActionResult AlarmDate()
        {
            return View();
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
