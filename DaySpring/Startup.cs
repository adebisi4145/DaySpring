using DaySpring.Implementations.Repositories;
using DaySpring.Implementations.Services;
using DaySpring.Interfaces.Repositories;
using DaySpring.Interfaces.Services;
using DaySpring.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaySpring
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
            services.AddControllersWithViews(); 
            services.AddDbContext<DaySpringDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString")));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<IMemberService, MemberService>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();

            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IPreacherRepository, PreacherRepository>();
            services.AddScoped<IPreacherService, PreacherService>();
            services.AddScoped<ISermonRepository, SermonRepository>();
            services.AddScoped<ISermonService, SermonService>();
            services.AddScoped<IAnnouncementRepository, AnnouncementRepository>();
            services.AddScoped<IAnnouncementService, AnnouncementService>();
            services.AddScoped<IColorRepository, ColorRepository>();
            services.AddScoped<IColorService, ColorService>();
            services.AddScoped<ISizeRepository, SizeRepository>();
            services.AddScoped<ISizeService, SizeService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddHttpContextAccessor();

            services.AddHostedService<MyBackgroundService>();


            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(config =>
                {
                    config.LoginPath = "/user/login";
                    config.Cookie.Name = "DaySpring";
                });
           
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

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
