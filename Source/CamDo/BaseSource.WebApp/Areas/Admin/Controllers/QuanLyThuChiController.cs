using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BaseSource.WebApp.Areas.Admin.Controllers
{
    public class QuanLyThuChiController : BaseAdminController
    {

        public async Task<IActionResult>  Expense()
        {
            return View();
        }
        public async Task<IActionResult> Income()
        {
            return View();
        }
    }
}
