using Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Infrastructure.DataAccess;
using Application;
using UserLogin.CookieLogin;

namespace UserLogin
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddRazorPages();
            builder.Services.AddDefaultIdentity<CustomUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<AppDbContext>();
            builder.Services.AddCookieAuthentication();
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            var app = builder.Build();
            
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthorization();
            app.MapRazorPages();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            //using (var scope = app.Services.CreateScope())
            //{
            //    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            //    var roles = new[] { "admin", "user", "employee" };
            //    foreach (var item in roles)
            //    {
            //        if (!(await roleManager.RoleExistsAsync(item)))
            //            await roleManager.CreateAsync(new IdentityRole(item));
            //    }
            //}
            app.Run();
        }
    }
}