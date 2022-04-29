using Microsoft.AspNetCore.Authorization;
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
        private Guid? _userId;
        public Guid? UserId
        {
            get { return _userId ?? (string.IsNullOrEmpty(User.FindFirstValue(ClaimTypes.NameIdentifier)) ? null : new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier))); }
            set { _userId = value; }
        }
    }
}
