
using Microservices.Web.Service;
using Microservices.Web.Service.IService;
using Microservices.Web.Utility;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Microservices.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllersWithViews();


            SD.GradoAPIBase = builder.Configuration["ServiceUrls:GradoAPI"];
            SD.AuthAPIBase = builder.Configuration["ServiceUrls:AuthAPI"];
            SD.DependenciaAPIBase = builder.Configuration["ServiceUrls:DependenciaAPI"];


            builder.Services.AddHttpContextAccessor(); //Accesder a nuestro navagador
            builder.Services.AddHttpClient();

            //Son los que van a tener comunicacion con el back
            builder.Services.AddHttpClient<IGradoService, GradoService>();
            builder.Services.AddHttpClient<IAuthService, AuthService>();
            builder.Services.AddHttpClient<IDependenciaService, DependenciaService>();

            //Son los registros de servicios como tal
            builder.Services.AddScoped<ITokenProvider, TokenProvider>();
            builder.Services.AddScoped<IBaseService, BaseService>();
            builder.Services.AddScoped<IGradoService, GradoService>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IDependenciaService, DependenciaService>();


            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromHours(10);
                options.LoginPath = "/Auth/Login";
                options.AccessDeniedPath = "/Auth/AccessDenied";
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for Dependenciaion scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
