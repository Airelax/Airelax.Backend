using System.Text;
using Airelax.Application;
using Airelax.Application.Houses;
using Airelax.Defines;
using Airelax.EntityFramework.DbContexts;
using Airelax.Hubs;
using Airelax.Infrastructure.Map;
using Airelax.Infrastructure.ThirdPartyPayment.ECPay;
using Airelax.Middlewares;
using Lazcat.Infrastructure.ExceptionHandlers;
using Lazcat.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
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
        public IHostEnvironment HostEnvironment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connectString;
            // if (HostEnvironment.IsDevelopment())
            // {
            //     connectString = Define.Database.LOCAL_CONNECT_STRING;
            //     services.AddCors(opt => { opt.AddPolicy("dev", builder => builder.WithOrigins("http://localhost:8080").AllowCredentials().AllowAnyHeader()); });
            // }
            // else
            {
                connectString = Define.Database.DB_CONNECT_STRING;
                services.AddCors(opt => { opt.AddPolicy("dev", builder => builder.WithOrigins("http://airelax.azurewebsites.net").AllowAnyMethod().AllowAnyHeader().AllowCredentials()); });
                //todo remove product
                //connectString = Define.Database.LOCAL_CONNECT_STRING;
            }
            // dotnet ef --startup-project Airelax migrations add $description -p Airelax.EntityFramework
            // 更新資料庫 dotnet ef --startup-project Airelax database update -p Airelax.EntityFramework

            services.AddDbContext<AirelaxContext>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString(connectString),
                    x =>
                    {
                        x.MigrationsAssembly(Define.Database.ENTITY_FRAMEWORK);
                        x.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                    })
            );
            
            services.AddByDependencyInjectionAttribute();
            services.AddControllersWithViews();
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "Airelax", Version = "v1"}); });
            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddGoogleGeoService(Configuration);
            services.AddECPayService(Configuration);
            services.Configure<PhotoUploadSetting>(Configuration.GetSection(nameof(PhotoUploadSetting)));

            // services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //     .AddCookie(options =>
            //     {
            //         options.LoginPath = "/Account/Login";
            //         options.LogoutPath = "/";
            //     })
            //    

            services.AddAuthentication(opt => { opt.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme; }).AddCookie(opt =>
            {
                opt.LoginPath = "/Account/Login";
                opt.LogoutPath = "/";
            }).AddJwtBearer(option =>
            {
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddControllersWithViews();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            // SignalR
            services.AddSignalR();
            //    .AddAzureSignalR(options =>
            //{
            //    options.ConnectionString = "Endpoint=https://airelax-signalr.service.signalr.net;AccessKey=i/uHEFtaqirRH/V0zreuc1mWHK15ASvCipxod6M63zg=;Version=1.0;";
            //});
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
            app.UseExceptionHandler(builder => builder.Run(async context => await ExceptionHandler.HandleError(context)));

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();
            //app.UseFileServer();
            if (env.IsDevelopment())
            {
                app.UseCors("dev");
            }
            
            app.UseMiddleware<RequestHeaderMiddleware>();
            app.UseWebSockets();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "default",
                    "{controller=Error}/{action=Index}/{id?}");
                // SignalR
                endpoints.MapHub<ChatHub>("/chathub");
            });
        }
    }
}