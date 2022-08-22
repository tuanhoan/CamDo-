using Microsoft.AspNetCore.Mvc;

namespace BaseSource.AdminApp.Controllers
{
    public class RoleController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
