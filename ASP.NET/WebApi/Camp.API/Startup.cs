using Camp.Data.DbContexts;
using Camp.Data.Repository.BaseRepository;
using Camp.Data.Repository.CampRepository;
using Camp.Data.Repository.SpeakerRepository;
using Camp.Data.Repository.TalkRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Camp.API
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
            services.AddDbContextPool<CampDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("CampDb"),
                b => b.MigrationsAssembly(typeof(CampDbContext).Assembly.FullName));
            });

            services.AddScoped(typeof(IRepository<>), typeof(SQLServerRepository<>));
            services.AddScoped<ICampRepository, SqlServerCampRepository>();
            services.AddScoped<ISpeakerRepository, SqlServerSpeakerRepository>();
            services.AddScoped<ITalkRepository,SqlServerTalkRepository > ();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
