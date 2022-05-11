﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BaseSource.BackendApi.Areas.Admin.Controllers
{
    [ApiController]
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("api/[area]/[controller]")]
    public class BaseAdminApiController : ControllerBase
    {
        private string _userId;
        public string UserId
        {
            get { return _userId ?? User.FindFirstValue(ClaimTypes.NameIdentifier); }
            set { _userId = value; }
        }
    }
}
