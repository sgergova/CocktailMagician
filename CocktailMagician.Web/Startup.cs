using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CocktailMagician.Data.AppContext;
using CocktailMagician.Data.Entities;
using CocktailMagician.Services;
using CocktailMagician.Services.Contracts;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using CocktailMagician.Web.Middleware;
using NToastNotify;

namespace CocktailMagician
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
            services.AddDbContext<CMContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("MyConnection")));

            //Register services
            services.AddScoped<IBarServices, BarServices>();
            services.AddScoped<IIngredientServices, IngredientServices>();
            services.AddScoped<ICocktailServices, CocktailServices>();
            services.AddScoped<ICountryServices, CountryServices>();
            services.AddScoped<IUploadImagesServices, UploadImagesServices>();

            services.AddMvc().AddNToastNotifyToastr(new ToastrOptions()
            {
                PositionClass = ToastPositions.TopCenter
            });


            services.AddDefaultIdentity<User>()
              .AddRoles<Role>()
              .AddEntityFrameworkStores<CMContext>()
              .AddDefaultUI()
              .AddDefaultTokenProviders();


            services.Configure<IdentityOptions>(option =>
            {
                option.Password.RequireDigit = false;
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequireUppercase = false;
                option.Password.RequireLowercase = false;
                option.Password.RequiredLength = 5;
                option.Password.RequiredUniqueChars = 0;
            });

            
            services.AddAuthentication().AddGoogle(o =>
                {
                    o.ClientId = Configuration["Google:ClientId"];
                    o.ClientSecret = Configuration["Google:ClientSecret"];
                });


            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
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

           // app.UseMiddleware<PageNotFound>();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
