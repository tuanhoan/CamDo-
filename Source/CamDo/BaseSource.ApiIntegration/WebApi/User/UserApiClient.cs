
using BaseSource.Shared.Constants;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.User;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using BaseSource.Utilities.Helper;
using Microsoft.AspNetCore.Identity;
using BaseSource.ViewModels.Admin;

namespace BaseSource.ApiIntegration.WebApi
{
    public class UserApiClient : IUserApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ApiResult<string>> ConfirmEmail(ConfirmEmailVm model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<string>>("/api/Account/ConfirmEmail", model);
        }

        public async Task<ApiResult<string>> ForgotPassword(ForgotPasswordVm model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<string>>("/api/Account/ForgotPassword", model);

        }

        public async Task<ApiResult<string>> Authenticate(LoginRequestVm model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            var result = await client.PostAsync<ApiResult<string>>("/api/Account/Authenticate", model);
            return result;
        }
        public async Task<ApiResult<string>> Register(RegisterRequestVm model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<string>>("/api/Account/Register", model);

        }

        public async Task<ApiResult<string>> ResetPassword(ResetPasswordVm model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<string>>("/api/Account/ResetPassword", model);
        }

        public async Task<ApiResult<UserInfoResponse>> GetUserInfo()
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<UserInfoResponse>>("/api/Account/GetUserInfo");
        }

        public async Task<ApiResult<string>> LogOut()
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<string>>("/api/Account/LogOut");
        }

        public async Task<ApiResult<string>> EditProfile(EditProfileVm model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<string>>("/api/Account/EditProfile", model);
        }

        public async Task<ApiResult<string>> ChangePassword(ChangePasswordVm model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<string>>("/api/Account/ChangePassword", model);
        }

        public async Task<ApiResult<string>> AuthenticateExternalAsync(UserClaimRequest model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<string>>("/api/Account/authenticateExternal", model);
        }

        public async Task<ApiResult<List<UserInfoResponse>>> GetUserByCuaHang()
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<List<UserInfoResponse>>>("/api/Account/GetUserByCuaHang");
        }
        public async Task<ApiResult<string>> CreateOrUpdate(EditUserShop model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsync<ApiResult<string>>("/api/User/CreateOrUpdate", model);
        }
        public async Task<ApiResult<EditUserShop>> GetUserById(string userId = default)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<EditUserShop>>($"/api/User/GetUserById/{userId}");
        }
        public async Task<ApiResult<string>> DeleteUser(string userId = default)
        {
            var dic = new Dictionary<string, string>()
            {
                { "userId", userId.ToString() }
            };
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.PostAsyncFormUrl<ApiResult<string>>($"/api/User/DeleteUser", dic);
        } 
        public async Task<ApiResult<PagedResult<UserShop>>> GetPagings(GetUserPagingRequest_Admin model)
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<PagedResult<UserShop>>>("/api/User/GetPagings", model);
        }

        public async Task<ApiResult<List<UserInfoResponse>>> GetKHByCuaHang()
        {
            var client = _httpClientFactory.CreateClient(SystemConstants.AppSettings.BackendApiClient);
            return await client.GetAsync<ApiResult<List<UserInfoResponse>>>("/api/Account/GetKHByCuaHang");
        }
    }
}
