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
    public class ThongBaoViewComponent : ViewComponent
    {
        private readonly IUserApiClient _userApiClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ThongBaoViewComponent(IUserApiClient userApiClient, IHttpContextAccessor httpContextAccessor)
        {
            _userApiClient = userApiClient;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _userApiClient.ThongBaoResponse();
            //var result = new ThongBaoResponse()
            //{
            //    AlarmDate = 10,
            //    Capital= 2,
            //    Installment=3,
            //    Loan= 4,
            //    Pawn= 8
            //};
            return View("Default", result.ResultObj);
        }
    }
}
