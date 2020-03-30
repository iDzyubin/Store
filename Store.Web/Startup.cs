using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Store.BusinessLogic.Mapper;
using Store.BusinessLogic.Services;
using Store.BusinessLogic.Services.Account;
using Store.BusinessLogic.Services.Basket;
using Store.BusinessLogic.Services.Password;
using Store.BusinessLogic.Services.Sale;
using Store.DataAccess.Interfaces;
using Store.DataAccess.Repositories;
using Store.Web.Filters;

namespace Store.Web
{
    public class Startup
    {
        public Startup( IConfiguration configuration )
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        
        // This method gets called by the runtime.
        // Use this method to add services to the container.
        public void ConfigureServices( IServiceCollection services )
        {
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();
            
            services.AddTransient<IPasswordService, PasswordService>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddSingleton<IBasketService, BasketService>();
            services.AddTransient<ISaleService, SaleService>();
            services.AddTransient<GreetingService>();
            
            RegisterCookieAuthentication( services );
            RegisterAutoMapper( services );
            
            services
                .AddControllersWithViews(options => options.Filters.Add<UserClaimsFilter>())
                .AddRazorRuntimeCompilation();
        }

        
        // This method gets called by the runtime.
        // Use this method to configure the HTTP request pipeline.
        public void Configure( IApplicationBuilder app, IWebHostEnvironment env )
        {
            if( env.IsDevelopment() )
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler( "/Home/Error" );
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints( endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}" );
            } );
        }


        /// <summary>
        /// Регистрация куки.
        /// </summary>
        /// <param name="services"></param>
        private static void RegisterCookieAuthentication( IServiceCollection services )
        {
            services
                .Configure<CookiePolicyOptions>( options =>
                {
                    options.CheckConsentNeeded    = context => true;
                    options.MinimumSameSitePolicy = SameSiteMode.None;
                } );

            services
                .AddAuthentication( CookieAuthenticationDefaults.AuthenticationScheme )
                .AddCookie( options =>
                {
                    options.LoginPath  = "/Account/Login";
                    options.LogoutPath = "/Account/Logout";
                } );
        }
        
        
        /// <summary>
        /// Регистрация автомаппера.
        /// </summary>
        /// <returns></returns>
        private void RegisterAutoMapper( IServiceCollection services )
        {
            var mappingConfig = new MapperConfiguration( mc =>
            {
                mc.AddProfile<UserProfile>();
            } );
            services.AddSingleton( mappingConfig.CreateMapper() );
        }
    }
}