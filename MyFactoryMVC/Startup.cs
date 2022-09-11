using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyFactoryMVC.Data;
using MyFactoryMVC.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFactoryMVC
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true) //Email se treba potvrdiit, ruèno u bazi potvrditi ljude
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            Task.Run(() => this.CreateRoles(roleManager, userManager)).Wait();
        }

        private async Task CreateRoles(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            if (!await roleManager.RoleExistsAsync("SUPERADMIN"))
            {
                await roleManager.CreateAsync(new IdentityRole("SUPERADMIN"));

                var user = new ApplicationUser
                {
                    Id = new Guid().ToString(),
                    Email = "admin@legitFactory.com",
                    EmailConfirmed = true,
                    UserName = "admin@legitFactory.com",
                    NormalizedEmail = "admin@legitFactory.com".ToUpper(),
                    NormalizedUserName = "admin@legitFactory.com".ToUpper()
                };

                var result = await userManager.CreateAsync(user, "SAdm1n!");
                if (!result.Succeeded)
                {
                    throw new Exception("DOOM AND GLOOM!!! KILL IT WITH FIRE!!!");
                }
                await userManager.AddToRoleAsync(user, "SUPERADMIN");

                foreach (string rol in this.Configuration.GetSection("Roles").Get<List<string>>())
                {
                    if (!await roleManager.RoleExistsAsync(rol))
                    {
                        await roleManager.CreateAsync(new IdentityRole(rol));
                    }
                   await userManager.AddToRoleAsync(user, rol);
                }
            }


        }
    }

   
}
