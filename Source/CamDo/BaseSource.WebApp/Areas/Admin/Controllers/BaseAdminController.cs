using BaseSource.WebApp.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BaseSource.WebApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "ShopManager")]
    [Area("Admin")]
    public class BaseAdminController : BaseController
    {
        private string _userId;
        public string UserId
        {
            get { return _userId ?? User.FindFirstValue(ClaimTypes.NameIdentifier); }
            set { _userId = value; }
        }
        public int ShopId
        {
            get
            {
                if (!string.IsNullOrEmpty(User.FindFirstValue("CuaHangId")))
                {
                    return int.Parse(User.FindFirstValue("CuaHangId"));
                }
                return 0;
            }

        }
        public string ShopName
        {
            get
            {
                if (!string.IsNullOrEmpty(User.FindFirstValue("TenCuaHang")))
                {
                    return User.FindFirstValue("TenCuaHang");
                }
                return string.Empty;
            }

        }
        public string UserName
        {
            get
            {
                return User.FindFirstValue(ClaimTypes.Name) ?? string.Empty;
            }

        }
    }
}
