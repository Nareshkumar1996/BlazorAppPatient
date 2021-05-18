using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Healthware.Assist.Core.Constants;
using Healthware.Assist.Core.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Healthware.Server
{
    public static class AuthConfigurer
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            if (bool.Parse(configuration["Authentication:JwtBearer:IsEnabled"]))
            {
                services.AddAuthentication(options => {
                    options.DefaultAuthenticateScheme = "JwtBearer";
                    options.DefaultChallengeScheme = "JwtBearer";
                }).AddJwtBearer("JwtBearer", options =>
                {
                    options.Audience = configuration["Authentication:JwtBearer:Audience"];

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        // The signing key must match!
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["Authentication:JwtBearer:SecurityKey"])),

                        // Validate the JWT Issuer (iss) claim
                        ValidateIssuer = true,
                        ValidIssuer = configuration["Authentication:JwtBearer:Issuer"],

                        // Validate the JWT Audience (aud) claim
                        ValidateAudience = true,
                        ValidAudience = configuration["Authentication:JwtBearer:Audience"],

                        // Validate the token expiry
                        ValidateLifetime = true,

                        // If you want to allow a certain amount of clock drift, set that here
                        ClockSkew = TimeSpan.Zero
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                            {
                                context.Response.Headers.Add("Token-Expired", "true");
                            }
                            return Task.CompletedTask;
                        },
                          OnMessageReceived = DecodeTokenResolver
                    };
                });
                
                services.AddAuthorization(auth =>
                {
                    auth.AddPolicy("JwtBearer", new AuthorizationPolicyBuilder()
                        .AddAuthenticationSchemes("JwtBearer")
                        .RequireAuthenticatedUser().Build());
                });
            }
        }

        private static Task DecodeTokenResolver(MessageReceivedContext context)
        {

            var qsAuthToken = context.HttpContext.Request.Headers["token"].FirstOrDefault();
            if (qsAuthToken == null)
            {
                // Cookie value does not matches to querystring value
                return Task.CompletedTask;
            }
           
            context.Token = SimpleStringCipher.Instance.Decrypt(qsAuthToken, Application.DefaultPassPhrase);
            return Task.CompletedTask;
        }
    }
}
