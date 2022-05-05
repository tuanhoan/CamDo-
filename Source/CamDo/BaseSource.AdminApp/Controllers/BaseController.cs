using BaseSource.Shared.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSource.AdminApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var cookie = Request.Cookies[SystemConstants.AppSettings.Token];
            if (cookie == null)
            {
                context.Result = new RedirectToActionResult("Login", "Account", new { returnUrl = Request.Path.Value });
            }

            base.OnActionExecuting(context);
        }

    }
}
