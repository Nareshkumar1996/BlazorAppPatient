using System;
using System.Text;
using Healthware.Assist.Core.Extensions;
using log4net;

namespace Healthware.Assist.Core.Logging
{
    public interface ILog4NetLogger{}

    public class Log4NetLogger : ILogger, ILog4NetLogger
    {
        readonly ILog underlying_logger;

        public Log4NetLogger(ILog underlying_logger)
        {
            this.underlying_logger = underlying_logger;
        }

        public void Informational(string formattedMessage, params object[] arguments)
        {
            underlying_logger.Info(formattedMessage.FormatWith(arguments));
        }

        public void Debug(string formattedMessage, params object[] arguments)
        {
            underlying_logger.Debug(formattedMessage.FormatWith(arguments));
        }

        public void Thread(string formattedMessage, params object[] arguments)
        {
            Debug("On Thread: {0}, {1}", System.Threading.Thread.CurrentThread.ManagedThreadId, formattedMessage.FormatWith(arguments));
        }

        public virtual void Error(Exception error)
        {
            underlying_logger.Error(error);
        }

        public void Error(Exception error, params string[] additionalInformation)
        {
            StringBuilder items = new StringBuilder();

            foreach (var information in additionalInformation)
                items.AppendLine(information);

            underlying_logger.Error("{0}{1}{2}".FormatWith(Environment.NewLine,items.ToString(),error));
        }

        public void Test(string formatted_message, params object[] arguments)
        {
            Debug(formatted_message, arguments);
        }
    }
}