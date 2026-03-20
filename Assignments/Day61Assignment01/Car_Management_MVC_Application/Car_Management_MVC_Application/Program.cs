using Car_Management_MVC_Application.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Car_Management_MVC_Application
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<Car_Management_MVC_ApplicationContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Car_Management_MVC_ApplicationContext") ?? throw new InvalidOperationException("Connection string 'Car_Management_MVC_ApplicationContext' not found.")));

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(
             options => options.SignIn.RequireConfirmedAccount = false)
         .AddRoles<IdentityRole>()
         .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
            app.MapRazorPages();
            //using (var scope = app.Services.CreateScope())
            //{
            //    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            //    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

            //    // 1. Create the Role if it doesn't exist
            //    if (!await roleManager.RoleExistsAsync("Admin"))
            //    {
            //        await roleManager.CreateAsync(new IdentityRole("Admin"));
            //    }

            //    // 2. Assign the Role to a specific user by Email
            //    var user1 = await userManager.FindByEmailAsync("admin@test.com");
            //    if (user1 != null && !await userManager.IsInRoleAsync(user1, "Admin"))
            //    {
            //        await userManager.AddToRoleAsync(user1, "Admin");
            //    }
            //    // 1. Create the Role if it doesn't exist
            //    if (!await roleManager.RoleExistsAsync("Customer"))
            //    {
            //        await roleManager.CreateAsync(new IdentityRole("Customer"));
            //    }

            //    // 2. Assign the Role to a specific user by Email
            //    var user2 = await userManager.FindByEmailAsync("customer@test.com");
            //    if (user2 != null && !await userManager.IsInRoleAsync(user2, "Customer"))
            //    {
            //        await userManager.AddToRoleAsync(user2, "Customer");
            //    }
            //    // 1. Create the Role if it doesn't exist
            //    if (!await roleManager.RoleExistsAsync("User"))
            //    {
            //        await roleManager.CreateAsync(new IdentityRole("User"));
            //    }

            //    // 2. Assign the Role to a specific user by Email
            //    var user3 = await userManager.FindByEmailAsync("user@test.com");
            //    if (user3 != null && !await userManager.IsInRoleAsync(user3, "User"))
            //    {
            //        await userManager.AddToRoleAsync(user3, "User");
            //    }
            //}
                app.Run();
            
        }
    }
}
