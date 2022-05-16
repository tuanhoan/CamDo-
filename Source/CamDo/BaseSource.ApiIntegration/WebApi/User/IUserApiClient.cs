
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ApiIntegration.WebApi
{
    public interface IUserApiClient
    {
        Task<ApiResult<string>> Register(RegisterRequestVm model);
        Task<ApiResult<string>> Authenticate(LoginRequestVm model);
        Task<ApiResult<string>> ConfirmEmail(ConfirmEmailVm model);
        Task<ApiResult<string>> ForgotPassword(ForgotPasswordVm model);
        Task<ApiResult<string>> ResetPassword(ResetPasswordVm model);
        Task<ApiResult<UserInfoResponse>> GetUserInfo();
        Task<ApiResult<string>> EditProfile(EditProfileVm model);
        Task<ApiResult<string>> ChangePassword(ChangePasswordVm model);
        Task<ApiResult<string>> AuthenticateExternalAsync(UserClaimRequest model);
        Task<ApiResult<List<UserInfoResponse>>> GetUserByCuaHang();
    }
}
