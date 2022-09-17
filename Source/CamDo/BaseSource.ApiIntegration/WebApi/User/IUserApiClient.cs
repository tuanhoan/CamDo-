
using BaseSource.ViewModels.Admin;
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
        Task<ApiResult<PagedResult<UserShop>>> GetPagings(GetUserPagingRequest_Admin model);
        Task<ApiResult<string>> Register(RegisterRequestVm model);
        Task<ApiResult<string>> Authenticate(LoginRequestVm model);
        Task<ApiResult<string>> ConfirmEmail(ConfirmEmailVm model);
        Task<ApiResult<string>> ForgotPassword(ForgotPasswordVm model);
        Task<ApiResult<string>> ResetPassword(ResetPasswordVm model);
        Task<ApiResult<UserInfoResponse>> GetUserInfo();
        Task<ApiResult<ThongBaoResponse>> ThongBaoResponse(); 
         Task<ApiResult<string>> EditProfile(EditProfileVm model);
        Task<ApiResult<string>> ChangePassword(ChangePasswordVm model);
        Task<ApiResult<string>> AuthenticateExternalAsync(UserClaimRequest model);
        Task<ApiResult<List<UserInfoResponse>>> GetUserByCuaHang();
        Task<ApiResult<List<UserInfoResponse>>> GetKHByCuaHang();
        Task<ApiResult<EditUserShop>> GetUserById(string userId = default);
        Task<ApiResult<string>> CreateOrUpdate(EditUserShop model);
        Task<ApiResult<string>> DeleteUser(string userId = default);
        Task<ApiResult<DataLoadTreeRoleFunc>> TreeFuncAuth(string UserId = default);
        Task<ApiResult<string>> SetRoleByUser(ModelSaveFuncRole model);
        Task<ApiResult<string>> SetRoleForUser(string userId, string FuncId, bool check);



    }
}
