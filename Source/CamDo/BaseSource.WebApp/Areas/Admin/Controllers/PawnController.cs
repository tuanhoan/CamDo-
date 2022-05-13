using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSource.WebApp.Areas.Admin.Controllers
{
    public class PawnController : BaseAdminController
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return PartialView("_Create");
        }
    }
}
