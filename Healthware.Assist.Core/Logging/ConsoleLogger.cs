using System;
using System.IO;
using Healthware.Assist.Core.Extensions;

namespace Healthware.Assist.Core.Logging
{
    public class ConsoleLogger : ILogger
    {
        readonly TextWriter text_writer;

        public ConsoleLogger() : this(Console.Out)
        {
        }

        public ConsoleLogger(TextWriter text_writer)
        {
            this.text_writer = text_writer;
        }

        public void Informational(string formattedMessage, params object[] arguments)
        {
            text_writer.WriteLine(formattedMessage.FormatWith(arguments));
        }

        public void Debug(string formattedMessage, params object[] arguments)
        {
            text_writer.WriteLine(formattedMessage.FormatWith(arguments));
        }

        public void Thread(string formattedMessage, params object[] arguments)
        {
            Debug("On Thread: {0}, {1}", System.Threading.Thread.CurrentThread.ManagedThreadId, formattedMessage.FormatWith(arguments));
        }

        public void Error(Exception error)
        {
            text_writer.WriteLine(error);
        }

        public void Error(Exception error, params string[] additionalInformation)
        {
           
        }
    }
}