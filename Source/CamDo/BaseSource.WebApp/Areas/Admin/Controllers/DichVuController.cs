using BaseSource.ViewModels.BaoHiem;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSource.WebApp.Areas.Admin.Controllers
{
    public class DichVuController : BaseAdminController
    {
        public async Task<IActionResult>  Insurance()
        {
            return View();
        }


        public async Task<IActionResult> Pay()
        {
            return View();
        }
        public async Task<IActionResult> MuaBaoHiem()
        {
            var model = new CreateBaoHiemVM();
            return PartialView("MuaBaoHiem", model);
        }
    }
}
