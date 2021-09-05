using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Airelax.Application;
using Airelax.Defines;
using Airelax.EntityFramework.DbContexts;
using Airelax.Infrastructure.Map;
using Lazcat.Infrastructure.ExceptionHandlers;
using Lazcat.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
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
            if (HostEnvironment.IsDevelopment())
            {
                connectString = Define.Database.LOCAL_CONNECT_STRING;
                services.AddCors(opt => { opt.AddPolicy("dev", builder => builder.WithOrigins("http://localhost:8080")); });
            }
            else
            {
                connectString = Define.Database.DB_CONNECT_STRING;
            }
            // dotnet ef --startup-project Airelax migrations add $description -p Airelax.EntityFramework
            // ��s��Ʈw dotnet ef --startup-project Airelax database update -p Airelax.EntityFramework

            //if use local DB
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
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "Airelax", Version = "v1"}); });
            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddGoogleGeoService(Configuration);
            services.Configure<PhotoUploadSetting>(Configuration.GetSection(nameof(PhotoUploadSetting)));
            //line - login
            services.AddAuthentication(options =>
                {
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                })
                .AddCookie(options => { options.LoginPath = "/Account/Login"; })
                .AddJwtBearer(option =>
                {
                    option.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                })
                .AddOAuth("Line", "Line", options =>
                {
                    options.ClientId = "1656361877";
                    options.ClientSecret = "384ac2d24675db0c2185b84ec3db16f2";
                    options.AuthorizationEndpoint = "https://access.line.me/oauth2/v2.1/authorize";
                    options.TokenEndpoint = "https://api.line.me/oauth2/v2.1/token";
                    options.UserInformationEndpoint = "https://api.line.me/v2/profile";
                    options.CallbackPath = new PathString("/signin-line");

                    options.Scope.Add("profile");
                    options.Scope.Add("openid");

                    options.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "userId");
                    options.ClaimActions.MapJsonKey(ClaimTypes.Name, "displayName", "string");

                    options.Events = new OAuthEvents
                    {
                        OnCreatingTicket = async context =>
                        {
                            var request = new HttpRequestMessage(HttpMethod.Get, context.Options.UserInformationEndpoint);
                            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", context.AccessToken);
                            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                            var response = await context.Backchannel.SendAsync(request, context.HttpContext.RequestAborted);
                            response.EnsureSuccessStatusCode();

                            var json = await response.Content.ReadAsStringAsync();
                            var user = JsonDocument.Parse(json);

                            context.RunClaimActions(user.RootElement);
                        },
                        OnRemoteFailure = context =>
                        {
                            context.HandleResponse();
                            context.Response.Redirect("/Account/Error?message=" + context.Failure.Message);
                            return Task.FromResult(0);
                        }
                    };
                });
            services.AddControllersWithViews();

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
            app.UseExceptionHandler(builder => builder.Run(async context => await ExceptionHandler.HandleError(context)));

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors("dev");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}