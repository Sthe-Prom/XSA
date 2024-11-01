using Microsoft.AspNetCore.Http;

using Microsoft.Extensions.DependencyInjection;
using XSA.Interfaces;
using XSA.Models;
using XSA.Services;

namespace XSA.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
            IConfiguration config)
        {
            // services.AddDbContext<AppIdentityDbContext>(opt =>
            // {
            //     opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            //     //opt.UseSqlServer(config.GetConnectionString("Prod"));
            // });

            //Identity
            // services.AddIdentity<User, IdentityRole>(opt =>
            // {
            //     //Username Options
            //     opt.User.RequireUniqueEmail = true;

            //     //Password Options
            //     opt.Password.RequiredLength = 6;
            //     opt.Password.RequireNonAlphanumeric = false;
            //     opt.Password.RequireLowercase = false;
            //     opt.Password.RequireUppercase = false;
            //     opt.Password.RequireDigit = false;

            // }).AddEntityFrameworkStores<AppIdentityDbContext>()
            // .AddDefaultTokenProviders();

        
            // services.AddDbContext<AppDbContext>(opt =>
            // {
            //     opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            //     //opt.UseSqlServer(config.GetConnectionString("Prod"));
            // });


            //MVC - Route Config
            services.AddMvc(options => options.EnableEndpointRouting = false);


            //Configure Antiforgery options(i - Frame Spooky Repeller);
            // services.AddAntiforgery(options =>
            // {
            //     options.SuppressXFrameOptionsHeader = true;
            // });

            // services.ConfigureApplicationCookie(options =>
            // {
            //     options.Cookie.SameSite = SameSiteMode.None;
            //     options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            // });

            //Application Service Registration           
            services.AddTransient<INewsService, NewsService>();

            // services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            return services;
        }
    }
}