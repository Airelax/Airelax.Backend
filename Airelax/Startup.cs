using System;
using System.Text.Json;
using Airelax.Application;
using Airelax.Defines;
using Airelax.EntityFramework.DbContexts;
using Lazcat.Infrastructure.Extensions;
using Lazcat.Infrastructure.Map;
using Lazcat.Infrastructure.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;

namespace Airelax
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostEnvironment hostEnvironment)
        {
            Configuration = configuration;
            HostEnvironment = hostEnvironment;
        }

        public IConfiguration Configuration { get; }
        public IHostEnvironment HostEnvironment { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // dotnet ef --startup-project Airelax migrations add $description -p Airelax.EntityFramework
            // dotnet ef --startup-project Airelax database update -p Airelax.EntityFramework

            //if use local DB
            var connectString = HostEnvironment.IsDevelopment() ? Define.Database.LOCAL_CONNECT_STRING : Define.Database.DB_CONNECT_STRING;
            services.AddDbContext<AirelaxContext>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString(connectString),
                    x =>
                    {
                        x.MigrationsAssembly(Define.Database.ENTITY_FRAMEWORK);
                        x.UseQuerySplittingBehavior(QuerySplittingBehavior.SingleQuery);
                    })
            );

            services.AddByDependencyInjectionAttribute();
            services.AddControllersWithViews();
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "Airelax", Version = "v1" }); });
            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddHttpClient<GoogleGeocodingService>();
            services.Configure<GoogleMapApiSetting>(Configuration.GetSection(nameof(GoogleMapApiSetting)));

            services.AddCors(opt => { opt.AddPolicy("dev", builder => builder.WithOrigins("http://localhost:8080")); });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Airelax v1"));
            }

            //app.UseHttpsRedirection();
            app.UseSerilogRequestLogging();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors("dev");
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