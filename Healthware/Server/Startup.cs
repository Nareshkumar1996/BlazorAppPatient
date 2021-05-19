using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using System.Text;
using Castle.MicroKernel.Registration;
using Healthware.Assist.Core.Constants;
using Healthware.Assist.Core.Containers;
using Healthware.Assist.Core.Startup;
using Healthware.Assist.Core.Web.Authentication.JwtBearer;
using Healthware.Assist.Core.Web.Authorization;
using Healthware.Assist.Core.Web.Configuration;
using Healthware.Server.Data;
using Healthware.Server.Repositories;
using Healthware.Server.Service;
using Healthware.Shared;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Healthware.Server
{
    public class Startup
    {
        private readonly IConfigurationRoot _appConfiguration;
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _appConfiguration = env.GetAppConfiguration();
            
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var container = Ioc.WireupApi(Start.TheApplication());
            services.AddDbContext<PatientDbContext>(options =>
                options.UseSqlServer(
                    _appConfiguration.GetConnectionString(Portal.ConnectionStringName)));
            AuthConfigurer.Configure(services, _appConfiguration);
            services.AddIdentity<User, Role>();
            services.AddScoped<PatientServiceDapper, PatientServiceDapper>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            
            services.AddScoped<IJwtHelper, JwtHelper>();
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddTransient<IUserStore<User>, UserRepository>();
            services.AddTransient<IRoleStore<Role>, RoleRepository>();
            services.AddScoped<UserManager<User>>();
            services.AddScoped<RoleManager<Role>>();
            container.Register(Component.For<TokenAuthConfiguration>().LifestyleSingleton());
            var tokenAuthConfig = Resolve.AnImplementationOf<TokenAuthConfiguration>();
            tokenAuthConfig.Issuer = "http://localhost:44390";
            tokenAuthConfig.SecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("PatientPortal_C421AAEE0D114E9C"));
            
            tokenAuthConfig.Audience = "http://localhost:44390";
            tokenAuthConfig.SigningCredentials = new SigningCredentials(tokenAuthConfig.SecurityKey, SecurityAlgorithms.HmacSha256);
            tokenAuthConfig.Expiration = TimeSpan.FromDays(1);
            services.AddSingleton<TokenAuthConfiguration>(tokenAuthConfig);
            container.Register(Component.For<IUserClaimsPrincipalFactory<User>>()
                .ImplementedBy<CoreUserClaimsPrincipalFactory<User, Role>>()
                .LifestyleScoped());
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer(options =>
            //    {
            //        options.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            ValidateIssuer = true,
            //            ValidateAudience = true,
            //            ValidateLifetime = true,
            //            ValidateIssuerSigningKey = true,
            //            ValidIssuer = Configuration["Jwt:Issuer"],
            //            ValidAudience = Configuration["Jwt:Issuer"],
            //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
            //        };
            //    });
            //services.AddAuthorization(auth =>
            //{
            //    auth.AddPolicy("Jwt", new AuthorizationPolicyBuilder()
            //        .AddAuthenticationSchemes("Jwt")
            //        .RequireAuthenticatedUser().Build());
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
