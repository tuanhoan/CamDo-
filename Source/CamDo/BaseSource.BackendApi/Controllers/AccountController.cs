using BaseSource.BackendApi.Services.Email;
using BaseSource.Data.EF;
using BaseSource.Data.Entities;
using BaseSource.ViewModels.Common;
using BaseSource.ViewModels.Mail;
using BaseSource.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.BackendApi.Controllers
{

    public class AccountController : BaseApiController
    {
        private readonly BaseSourceDbContext _db;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IConfiguration _configuration;

        private readonly ISendEmailService _emailService;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountController(BaseSourceDbContext db, SignInManager<AppUser> signInManager,
            UserManager<AppUser> userManager, IConfiguration configuration, ISendEmailService emailService,
             IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _signInManager = signInManager;
            _userManager = userManager;
            _configuration = configuration;
            _emailService = emailService;
            _httpContextAccessor = httpContextAccessor;

        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterRequestVm model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }

            if (await _userManager.FindByNameAsync(model.UserName) != null)
            {
                ModelState.AddModelError("UserName", "UserName already exists");
                return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            if (await _userManager.FindByEmailAsync(model.Email) != null)
            {
                ModelState.AddModelError("Email", "Email already existss");
                return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }

            var appUser = new AppUser()
            {
                Email = model.Email,
                UserName = model.UserName,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(appUser, model.Password);

            if (result.Succeeded)
            {
                var userDetail = new UserProfile()
                {
                    UserId = appUser.Id.ToString(),
                    FullName = model.UserName,
                    CustomId = appUser.Id.ToString()
                };
                _db.UserProfiles.Add(userDetail);
                _db.SaveChanges();

                //var code = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);
                //code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

                //var rs = Task.Run(() => _emailService.SendMailConfirmEmail(appUser.UserName, appUser.Email, appUser.Id, code));

                return Ok(new ApiSuccessResult<string>());
            }

            AddErrors(result, nameof(model.UserName));
            return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));
        }
        [HttpPost("Authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate(LoginRequestVm user)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var existingUser = await _userManager.FindByNameAsync(user.UserName) ?? await _userManager.FindByEmailAsync(user.UserName);
            if (existingUser == null)
            {
                ModelState.AddModelError("UserName", "User không tồn tại trong hệ thống");
                return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }

            //if (!existingUser.EmailConfirmed)
            //{
            //    var code = await _userManager.GenerateEmailConfirmationTokenAsync(existingUser);
            //    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

            //    var rs = Task.Run(() => _emailService.SendMailConfirmEmail(existingUser.UserName, existingUser.Email, existingUser.Id, code));

            //    ModelState.AddModelError("Email", "Please verify your email before logging in.");
            //    return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));
            //}

            var result = await _signInManager.PasswordSignInAsync(existingUser, user.Password, true, false);
            if (!result.Succeeded)
            {
                if (result.RequiresTwoFactor)
                {
                    ModelState.AddModelError("UserName", "Requires Two Factor.");
                }
                if (result.IsLockedOut)
                {
                    ModelState.AddModelError("UserName", "User account locked out.");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "The username or password is incorrect.");
                }
                return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }

            var jwtToken = await GenerateJwtToken(existingUser);
            return Ok(new ApiSuccessResult<string>(jwtToken));
        }

        [HttpPost("ConfirmEmail")]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(ConfirmEmailVm model)
        {

            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
            {
                return Ok(new ApiErrorResult<string>());
            }

            model.Code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(model.Code));
            // Xác thực email
            var result = await _userManager.ConfirmEmailAsync(user, model.Code);
            if (result.Succeeded)
            {
                return Ok(new ApiSuccessResult<string>());
            }

            AddErrors(result, nameof(model.Code));
            return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));
        }

        [HttpPost("ForgotPassword")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordVm model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError("Email", "Email does not exist");
                return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            else
            {
                var tokenGenerated = await _userManager.GeneratePasswordResetTokenAsync(user);
                byte[] tokenGeneratedBytes = Encoding.UTF8.GetBytes(tokenGenerated);
                var codeEncoded = WebEncoders.Base64UrlEncode(tokenGeneratedBytes);

                var mailContent = new MailContentVm()
                {
                    UserID = user.Id,
                    Code = codeEncoded,
                    To = user.Email
                };

                await _emailService.SendMailResetPassword(mailContent);
                return Ok(new ApiSuccessResult<string>());
            }


        }
        [HttpPost("ResetPassword")]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(ResetPasswordVm model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError("Email", "Email does not exist");
                return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            else
            {
                var codeDecodedBytes = WebEncoders.Base64UrlDecode(model.Code);
                var codeDecoded = Encoding.UTF8.GetString(codeDecodedBytes);

                var result = await _userManager.ResetPasswordAsync(user, codeDecoded, model.Password);
                if (result.Succeeded)
                {
                    return Ok(new ApiSuccessResult<string>());
                }

                AddErrors(result, nameof(model.Email));
                return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
        }

        [HttpGet("GetUserInfo")]
        public async Task<IActionResult> GetUserInfo()
        {
            var user = await _db.Users.FindAsync(UserId);
            var roles = await _userManager.GetRolesAsync(user);
            var profile = await _db.UserProfiles.FindAsync(UserId);

            var model = new UserInfoResponse
            {
                Id = user.Id.ToString(),
                Email = user.Email,
                FullName = profile?.FullName,
                UserName = user.UserName,
                JoinedDate = profile?.JoinedDate,
                PhoneNumber = user.PhoneNumber,
                Roles = roles.ToList()
            };

            return Ok(new ApiSuccessResult<UserInfoResponse>(model));
        }

        [HttpPost("EditProfile")]
        public async Task<IActionResult> EditProfile(EditProfileVm model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            var user = await _db.Users.Include(x => x.UserProfile).Where(x => x.Id == UserId).FirstOrDefaultAsync();
            user.PhoneNumber = model.PhoneNumber;
            user.UserProfile.FullName = model.FullName;
            user.Email = model.Email;
            user.NormalizedEmail = model.Email;
            await _db.SaveChangesAsync();
            return Ok(new ApiSuccessResult<string>("Cập nhật thông tin thành công"));

        }

        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordVm model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }

            var user = await _userManager.FindByIdAsync(UserId);

            var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                await _db.SaveChangesAsync();
                return Ok(new ApiSuccessResult<string>("Thay đổi mật khẩu thành công"));
            }

            ModelState.AddModelError(nameof(model.OldPassword), "Mật khẩu cũ không đúng");
            return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));

        }
        /// <summary>
        /// Authenticate External(Google,Facebook,...)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [Route("authenticateExternal")]
        public async Task<IActionResult> AuthenticateExternal(UserClaimRequest model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));
            }
            try
            {
                var user = await _db.Users.FirstOrDefaultAsync(x => x.Email.ToLower() == model.Email.ToLower());
                if (user != null)
                {
                    var userLogin = await _db.UserLogins.FirstOrDefaultAsync(x => x.UserId == user.Id && x.LoginProvider == model.Type && x.ProviderKey == model.Id);
                    //add provider login
                    if (userLogin == null)
                    {
                        _db.UserLogins.Add(new AppUserLogin
                        {
                            LoginProvider = model.Type,
                            ProviderDisplayName = model.Type,
                            ProviderKey = model.Id,
                            UserId = user.Id,
                        });
                        await _db.SaveChangesAsync();
                    }
                    var jwtToken = await GenerateJwtToken(user);
                    return Ok(new ApiSuccessResult<string>(jwtToken));
                }

                var newUser = new AppUser()
                {
                    Email = model.Email,
                    NormalizedEmail = model.Email.ToUpper(),
                    UserName = model.Email,
                    NormalizedUserName = model.Email.ToUpper(),
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                //insert user
                _db.Users.Add(newUser);

                _db.UserLogins.Add(new AppUserLogin
                {
                    LoginProvider = model.Type,
                    ProviderDisplayName = model.Type,
                    ProviderKey = model.Id,
                    UserId = newUser.Id,
                });

                _db.UserProfiles.Add(new UserProfile
                {
                    CustomId = newUser.Id,
                    FullName = model.GivenName,
                    JoinedDate = DateTime.Now,
                    UserId = newUser.Id
                });

                await _db.SaveChangesAsync();
                return Ok(new ApiSuccessResult<string>(await GenerateJwtToken(newUser)));
            }
            catch (Exception ex)
            {
                return Ok(new ApiErrorResult<string>($"Login{model.Type} failed! "));
            }

        }
        #region helper
        private void AddErrors(IdentityResult result, string Property)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(Property, error.Description);
                break;
            }
        }

        private async Task<string> GenerateJwtToken(AppUser user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var cuaHang = await _db.CuaHangs.OrderByDescending(x => x.CreatedTime).FirstOrDefaultAsync();

            var roles = await _userManager.GetRolesAsync(user);
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email,user.Email ?? ""),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim("CuaHangId", cuaHang?.Id.ToString() ?? "")
             };

            foreach (var item in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, item));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration["Tokens:Issuer"],
             _configuration["Tokens:Issuer"],
             claims,
             expires: DateTime.UtcNow.AddDays(15),
             signingCredentials: creds);

            var jwtToken = jwtTokenHandler.WriteToken(token);

            return jwtToken;
        }
        #endregion
    }
}
