using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Server.IIS;
using Microsoft.Extensions.Options;

namespace ExpenseManagementSystem
{
    public class Startup
    {
        public IConfiguration configRoot
        {
            get;
        }
        public Startup(IConfiguration configuration)
        {
            configRoot = configuration;
        }

       
        public void ConfigureServices(IServiceCollection services)
        {
            ////services.Configure<CookiePolicyOptions>(options =>
            ////{
            ////    options.CheckConsentNeeded = context => true;
            ////    options.MinimumSameSitePolicy = SameSiteMode.None;
            ////});


            ////  services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

          
            //CookieAuthenticationDefaults.AuthenticationScheme,options => {
            //    options.LoginPath = new PathString("/Login/SignIn");
            //    options.AccessDeniedPath = new PathString("/Login/SignIn");
            //});
            //services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_1);
            //services.AddAuthentication(NegotiateDefaults.AuthenticationScheme).AddNegotiate();
            services.AddControllersWithViews();
            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //.AddCookie(options =>
            //    {
            //        options.LoginPath="/Home/Login";

            //    });
            //services.AddRazorPages();
        }
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapRazorPages();
            app.Run();
        }
    }
}
