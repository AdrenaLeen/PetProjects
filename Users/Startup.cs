using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;
using Users.Infrastructure;
using Users.Models;

namespace Users
{
    public class Startup
    {
        readonly IConfigurationRoot configuration;

        public Startup(IWebHostEnvironment env)
        {
            configuration = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json").Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IPasswordValidator<AppUser>, CustomPasswordValidator>();
            services.AddTransient<IUserValidator<AppUser>, CustomUserValidator>();
            services.AddSingleton<IClaimsTransformation, LocationClaimsProvider>();
            services.AddTransient<IAuthorizationHandler, BlockUsersHandler>();
            services.AddTransient<IAuthorizationHandler, DocumentAuthorizationHandler>();
            services.AddAuthorization(opts =>
            {
                opts.AddPolicy("DCUsers", policy =>
                {
                    policy.RequireRole("Users");
                    policy.RequireClaim(ClaimTypes.StateOrProvince, "DC");
                });
                opts.AddPolicy("NotBob", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.AddRequirements(new BlockUsersRequirement("Bob"));
                });
                opts.AddPolicy("AuthorsAndEditors", policy =>
                {
                    policy.AddRequirements(new DocumentAuthorizationRequirement
                    {
                        AllowAuthors = true,
                        AllowEditors = true
                    });
                });
            });
            services.AddAuthentication().AddGoogle(opts =>
            {
                opts.ClientId = "144224494355-8n1mjcaji1rq0abc8jo8dcb5t6hgrqn2.apps.googleusercontent.com";
                opts.ClientSecret = "M8JOLMIkfh9gzZwRFrlS9Zuj";
            });
            services.AddDbContext<AppIdentityDbContext>(options => options.UseNpgsql(configuration["ConnectionStrings:SportsStoreIdentity"]));
            services.AddIdentity<AppUser, IdentityRole>(opts =>
            {
                opts.User.RequireUniqueEmail = true;
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<AppIdentityDbContext>();
            services.AddRazorPages();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseStatusCodePages();
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            AppIdentityDbContext.CreateAdminAccount(app.ApplicationServices, configuration).Wait();
        }
    }
}
