using GameOnlineShop.Data.Models;
using GameShop.Data;
using GameShop.Data.Interfaces;

using GameShop.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json.Serialization;


namespace GameOnlineShop
{
    public class Startup
    {
        private IConfigurationRoot _confString;

        /* public Startup(IHostEnvironment hostEnv)
         {
             _confString = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
         }*/

        public const string AuthMethod = "Smile";
        public Startup(Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Microsoft.Extensions.Configuration.IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var test = _confString.GetConnectionString("DefaultConnection");
            var test2 = Configuration.GetConnectionString("DefaultConnection");
            services.AddAuthentication();
           // services.AddDbContext<AppDBContent>(options => options.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));
            services.AddDbContext<AppDBContent>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
                services.AddIdentity<User, IdentityRole>(opts =>
                {
                    opts.Password.RequiredLength = 5;
                    opts.Password.RequireNonAlphanumeric = false;
                    opts.Password.RequireLowercase = false;
                    opts.Password.RequireUppercase = false;
                    opts.Password.RequireDigit = false;
                    opts.User.RequireUniqueEmail = true;
                }).AddEntityFrameworkStores<AppDBContent>()
                  .AddDefaultTokenProviders();
     

            /*

                        services.AddIdentity<Automobile.Models.Account, IdentityRole>(options =>
                {
                    options.User.RequireUniqueEmail = false;
                })
                .AddEntityFrameworkStores<Providers.Database.EFProvider.DataContext>()
                .AddDefaultTokenProviders();

             */

            services.AddTransient<IAllGames, GamesRepository>();
            services.AddTransient<IGamesCategory, CategoriesRepository>();
            services.AddTransient<IAllOrders, OrdersRepository>();
            services.AddTransient<IOrderProcess, EmailOrderProcess>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => GameShop.Data.Models.ShopCart.GetCart(sp));
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddMemoryCache();
            services.AddControllers().AddJsonOptions(x =>
   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
            services.AddSession();

            services.AddAuthentication()
          .AddCookie(AuthMethod, config =>
          {
              config.Cookie.Name = "Smile";
              config.LoginPath = "/Account/Login";
              config.AccessDeniedPath = "/Account/Login";
          });

            services.AddHttpContextAccessor();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
                app.UseStaticFiles();
                app.UseSession();

                app.UseHttpsRedirection();               

                app.UseRouting();

                app.UseAuthentication();

                app.UseAuthorization();
                app.UseMvc(routes =>
                {
                    routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
                    routes.MapRoute(name: "categoryFiler", template: "Game/{action}/{category?}", defaults: new { Controller = "Game", action = "List" });
                });
               
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>(); // get service for working with database
                    DBObjects.Initialize(content);
                }
            }
        }
    }
}
