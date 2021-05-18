using System;
using log4net;

namespace Healthware.Assist.Core.Logging
{
    public class LogFactory : ILogFactory
    {
        public LogFactory(ILogSettingsIntializer command)
        {
            command.Execute();
        }

        public ILogger CreateFor(Type type)
        {
            //return new Log4NetWithElmahLogger(LogManager.GetLogger(type));
            return new Log4NetLogger(LogManager.GetLogger(type));
        }
    }
}