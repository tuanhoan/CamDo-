using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using BaseSource.Shared.Constants;
using Microsoft.AspNetCore.Identity;
using BaseSource.ApiIntegration.WebApi;
using BaseSource.ApiIntegration.AdminApi;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using BaseSource.ApiIntegration.AdminApi.CauHinhHangHoa;
using BaseSource.ApiIntegration.WebApi.CuaHang;
using BaseSource.ApiIntegration.WebApi.CauHinhHangHoa;
using BaseSource.ApiIntegration.WebApi.MoTaHinhThucLai;
using BaseSource.ApiIntegration.WebApi.FeedBack;
using BaseSource.ApiIntegration.WebApi.HopDong;
using AutoMapper;
using BaseSource.ApiIntegration.WebApi.KhachHang;
using BaseSource.ApiIntegration.WebApi.HD_PaymentLog;
using BaseSource.ApiIntegration.WebApi.HD_PaymentLogNote;

namespace BaseSource.WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddHttpClient(SystemConstants.AppSettings.BackendApiClient, (sp, httpClient) =>
            {
                httpClient.BaseAddress = new Uri(Configuration.GetValue<string>("BackendApiBaseAddress"));

                // Find the HttpContextAccessor service
                var httpContextAccessor = sp.GetRequiredService<IHttpContextAccessor>();

                // Get the bearer token from the request context
                var bearerToken = httpContextAccessor.HttpContext.Request.Cookies[SystemConstants.AppSettings.Token];

                // Add authorization if found
                if (bearerToken != null)
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
            });

            services.AddControllersWithViews();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
           .AddCookie(options =>
           {
               options.LoginPath = "/Account/Login";
               options.AccessDeniedPath = "/User/Forbidden/";
           }).AddGoogle(options =>
           {
               // google Authentication
               options.ClientId = Configuration["Authentication:Google:ClientId"];
               options.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
               options.ClaimActions.MapJsonKey(ClaimTypes.Surname, "surname");
               options.ClaimActions.MapJsonKey("urn:google:picture", "picture", "url");
           })
           .AddFacebook(options =>
           {
               options.AppId = Configuration["Authentication:Facebook:AppId"];
               options.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
           });


            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/Account/Login";
                //options.Cookie.Name = "YourAppCookieName";
                //options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(15);
                options.LoginPath = "/Account/Login";
                // ReturnUrlParameter requires 
                //using Microsoft.AspNetCore.Authentication.Cookies;
                //options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                //options.SlidingExpiration = true;
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IUserApiClient, UserApiClient>();
            services.AddTransient<IExampleApiClient, ExampleApiClient>();
            services.AddTransient<ICuaHangApiClient, CuaHangApiClient>();
            services.AddTransient<ICauHinhHangHoaApiClient, CauHinhHangHoaApiClient>();
            services.AddTransient<IMoTaHinhThucLaiApiClient, MoTaHinhThucLaiApiClient>();
            services.AddTransient<IFeedBackApiClient, FeedBackApiClient>();
            services.AddTransient<IHopDongApiClient, HopDongApiClient>();
            services.AddTransient<IKhachHangApiClient, KhachHangApiClient>();
            services.AddTransient<IHD_PaymentLogApiClient, HD_PaymentLogApiClient>();
            services.AddTransient<IHD_PaymentLogNote, HD_PaymentLogNote>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();
            app.UseRequestLocalization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "areas",
                   pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                 );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
