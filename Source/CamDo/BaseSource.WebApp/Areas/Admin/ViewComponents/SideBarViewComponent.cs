using BaseSource.ApiIntegration;
using BaseSource.ApiIntegration.WebApi;
using BaseSource.ViewModels.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSource.WebApp.Areas.Admin.ViewComponents
{
    public class SideBarViewComponent : ViewComponent
    {
        private readonly IUserApiClient _userApiClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SideBarViewComponent(IUserApiClient userApiClient, IHttpContextAccessor httpContextAccessor)
        {
            _userApiClient = userApiClient;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _userApiClient.ListAuthenByUser();
            List<string> data = result.ResultObj.Split(",").ToList();
            return View("Default", data);
        }
    }
}
