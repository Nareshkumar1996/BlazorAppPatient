﻿using System.Collections.Concurrent;
using Healthware.Assist.Core.Configurations;
using Healthware.Assist.Core.Extensions;
using Microsoft.Extensions.Configuration;

namespace Healthware.Assist.Core.Web.Configuration
{
    public static class ApplicationSetting
    {
        private static readonly ConcurrentDictionary<string, IConfigurationRoot> _configurationCache;

        static ApplicationSetting()
        {
            _configurationCache = new ConcurrentDictionary<string, IConfigurationRoot>();
        }

        public static IConfigurationRoot Get(string path, string environmentName = null, bool addUserSecrets = false)
        {
            var cacheKey = path + "#" + environmentName + "#" + addUserSecrets;
            return _configurationCache.GetOrAdd(
                cacheKey,
                _ => BuildConfiguration(path, environmentName, addUserSecrets)
            );
        }

        private static IConfigurationRoot BuildConfiguration(string path, string environmentName = null, bool addUserSecrets = false)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            //if (!environmentName.IsNullOrWhiteSpace())
            //{
            //    builder = builder.AddJsonFile($"appsettings.{environmentName}.json", optional: true);
            //}

            builder = builder.AddEnvironmentVariables();

            //if (addUserSecrets)
            //{
            //    builder.AddUserSecrets(typeof(ApplicationSetting).GetAssembly());
            //}

            return builder.Build();
        }
    }
}
