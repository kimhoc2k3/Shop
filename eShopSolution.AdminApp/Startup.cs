using eShopSolution.ApiIntegration;
using eShopSolution.Data.EF;
using eShopSolution.Data.Entities;
using eShopSolution.ViewModel.System.Users;
using FluentValidation.AspNetCore;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace eShopSolution.AdminApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.public void ConfigureAppConfiguration(IConfigurationBuilder configurationBuilder)
        

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.LoginPath = $"/Login/Index";
                options.AccessDeniedPath = $"/User/Forbiden";
                
            });
            //services.AddIdentity<AppUser, AppRole>()
            //    .AddEntityFrameworkStores<eShopDbContext>()
            //    .AddDefaultTokenProviders();
            
            services.AddAuthorization(options =>
            {
                options.AddPolicy("admin", policy =>
                {
                    policy.RequireAssertion(context =>
                    {

                        var roles = context.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;

                        var listRolesElements = roles.Split(',').ToList();


                        return listRolesElements.Contains("admin");
                    });
                });


            });

            //services.AddDefaultIdentity<ApplicationUser>()
            //    .AddRoles<IdentityRole>()
            //    .AddEntityFrameworkStores<ICMSDbContext>()
            //    .AddClaimsPrincipalFactory<CustomClaimsPrincipalFactory>();
            //        services.AddIdentity<Tuser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
            //.AddEntityFrameworkStores<eShopDbContext>()
            //.AddClaimsPrincipalFactory<ClaimsPrincipal>()
            //.AddRoleManager<RoleManager<IdentityRole>>()
            //.AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>(TokenOptions.DefaultProvider);
            services.AddControllersWithViews().AddFluentValidation(fv =>
                                                fv.RegisterValidatorsFromAssemblyContaining<LoginRequestValidator>());


            services.AddSession(options => options.IdleTimeout = TimeSpan.FromMinutes(30));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<IUserApiClient, UserApiClient>();
            services.AddTransient<IRoleApiClient, RoleApiClient>();
            services.AddTransient<ILanguageApiClient, LanguageApiClient>();
            services.AddTransient<ICategoryApiClient, CategoryApiClient>();
            services.AddTransient<IProductApiClient, ProductApiClient>();
            services.AddTransient<ISlideApiClient, SlideApiClient>();



            IMvcBuilder builder = services.AddRazorPages();
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
#if DEBUG
            if (environment == Environments.Development)
            {   
                 builder.AddRazorRuntimeCompilation();
            }
#endif
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

            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
