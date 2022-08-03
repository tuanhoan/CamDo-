using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSource.BackendApi.Controllers
{
    public class IncomeAndExpenseController : Controller
    {
        public async Task<IActionResult> Income()
        {
            return View();
        }

        public async Task<IActionResult> Expense()
        {
            return View();
        }
    }
}
