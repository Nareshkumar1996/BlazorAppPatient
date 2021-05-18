using System.IO;
using Healthware.Assist.Core.Configurations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Healthware.Assist.Core.Web.Configuration
{
    public static class HostingEnvironmentExtensions
    {
        public static IConfigurationRoot GetAppConfiguration(this IWebHostEnvironment env)
        {
            return ApplicationSetting.Get(Path.Combine(env.ContentRootPath, "Config"), env.EnvironmentName, env.IsDevelopment());
        }
    }
}
