using BaseSource.ApiIntegration.WebApi;
using BaseSource.Shared.Constants;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static BaseSource.Shared.Constants.SystemConstants;

namespace BaseSource.AdminApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserApiClient _userApiClient;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public AccountController(IUserApiClient userApiClient,
            IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _userApiClient = userApiClient;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;

        }
     
        public async Task<IActionResult> Login(string returnUrl)
        {
            ClearAuthorizedCookies();
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestVm model, string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _userApiClient.Authenticate(model);
            if (!result.IsSuccessed)
            {
                bool isReturnView = false;
                var message = new MessageResult();
                if (result.ValidationErrors[0].Error == "Email is not confirm")
                {
                    message.Title = "Xác thực email";
                    message.Content = "Tài khoản email chưa xác thực. Một email đã được gửi đến Email của bạn. Vui lòng truy cập email để xác thực email trước khi đăng nhập.";
                    isReturnView = true;
                }

                if (result.ValidationErrors[0].Error == "User is Lockout")
                {

                    message.Title = "Khóa tài khoản";
                    message.Content = "Tài khoản của bạn đã bị khóa do đăng nhập sai mật khẩu quá nhiều lần. Vui lòng thử lại sau";
                    isReturnView = true;

                }
                if (isReturnView)
                {
                    return View("MessageViewResult", message);
                }

                ModelState.AddListErrors(result.ValidationErrors);
                return View(model);
            }
            //signin cookie
            await SignInCookie(result.ResultObj);
            return RedirectToLocal(returnUrl);

        }
        public async Task<IActionResult> Logout()
        {
            ClearAuthorizedCookies();
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login", "Account");
        }
        #region helper
        private ClaimsPrincipal ValidateToken(string jwtToken)
        {
            IdentityModelEventSource.ShowPII = true;

            SecurityToken validatedToken;
            TokenValidationParameters validationParameters = new TokenValidationParameters();

            validationParameters.ValidateLifetime = true;

            validationParameters.ValidAudience = _configuration["Tokens:Issuer"];
            validationParameters.ValidIssuer = _configuration["Tokens:Issuer"];
            validationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));

            ClaimsPrincipal principal = new JwtSecurityTokenHandler().ValidateToken(jwtToken, validationParameters, out validatedToken);

            return principal;
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        private void ClearAuthorizedCookies()
        {
            Response.Cookies.Append(AppSettings.Token, "", new CookieOptions()
            {
                Expires = DateTime.Now.AddDays(-1)
            });
        }
        private async Task SignInCookie(string token)
        {
            var userPrincipal = this.ValidateToken(token);
            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(15),
                IsPersistent = false
            };
            HttpContext.Response.Cookies.Append(SystemConstants.AppSettings.Token, token, new CookieOptions { HttpOnly = true, Expires = DateTimeOffset.UtcNow.AddDays(15) });
            await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        userPrincipal, authProperties);
        }
        #endregion
    }
}
