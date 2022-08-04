using BaseSource.ApiIntegration.AdminApi;
using BaseSource.ApiIntegration.AdminApi.BaiViet;
using BaseSource.ApiIntegration.AdminApi.CauHinhHangHoa;
using BaseSource.ApiIntegration.AdminApi.DanhMucBaiViet;
using BaseSource.ApiIntegration.AdminApi.FeedBack;
using BaseSource.ApiIntegration.AdminApi.GoiSanPham;
using BaseSource.ApiIntegration.AdminApi.LienHe;
using BaseSource.ApiIntegration.AdminApi.MoTaHinhThucLai;
using BaseSource.ApiIntegration.AdminApi.NotifySystem;
using BaseSource.ApiIntegration.AdminApi.ReportCustomer;
using BaseSource.ApiIntegration.WebApi;
using BaseSource.Shared.Constants;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BaseSource.AdminApp
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
            services.AddTransient<ICauHinhHangHoaAdminApiClient, CauHinhHangHoaAdminApiClient>();
            services.AddTransient<IMoTaHinhThucLaiAdmiApiClient, MoTaHinhThucLaiAdmiApiClient>();
            services.AddTransient<IFeedBackAdminApiClient, FeedBackAdminApiClient>();
            services.AddTransient<IReportCustomerAdminApiClient, ReportCustomerAdminApiClient>();
            services.AddTransient<IGoiSanPhamAdminApiClient, GoiSanPhamAdminApiClient>();
            services.AddTransient<INotifySystemAdminApiClient, NotifySystemAdminApiClient>();
            services.AddTransient<IUserAdminApiClient, UserAdminApiClient>();
            services.AddTransient<ILienHeAdminApiClient, LienHeAdminApiClient>();
            services.AddTransient<IDanhMucBaiVietAdminApiClient, DanhMucBaiVietAdminApiClient>();
            services.AddTransient<IBaiVietAdminApiClient, BaiVietAdminApiClient>();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
