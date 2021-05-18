using System;
using System.IO;
using System.Reflection;
using Healthware.Assist.Core.Utility;
using log4net;
using log4net.Config;

namespace Healthware.Assist.Core.Logging
{
    public interface ILogSettingsIntializer : ICommand
    {
    }

    public class LogSettingsInitializer : ILogSettingsIntializer
    {
        public void Execute()
        {

            var logRepo = LogManager.GetRepository(Assembly.GetEntryAssembly());

            var location = Path.Combine(AppDomain.CurrentDomain.RelativeSearchPath ?? AppDomain.CurrentDomain.BaseDirectory, "log4net.config");
            XmlConfigurator.Configure(logRepo, new FileInfo(location));
        }
    }
}
