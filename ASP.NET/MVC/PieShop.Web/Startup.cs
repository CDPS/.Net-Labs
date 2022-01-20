using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PieShop.Data.CategoryRepository;
using PieShop.Data.DBContexts;
using PieShop.Data.PieRepository;
using PieShop.Data.Repository;

namespace PieShop.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContextPool<PieShopDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("PieShopDb"),
                b => b.MigrationsAssembly(typeof(PieShopDbContext).Assembly.FullName));
            });


            services.AddScoped(typeof(IRepository<>), typeof(SQLServerRepository<>));
            services.AddScoped<IPieRepository, SqlServerPieRepository>();
            services.AddScoped<ICategoryRepository, SqlServerCategoryRepository>();
            services.AddControllersWithViews();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
