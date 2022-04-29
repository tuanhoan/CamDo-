using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSource.WebApp.Areas.Admin.Controllers
{
    public class HomeController : BaseAdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
