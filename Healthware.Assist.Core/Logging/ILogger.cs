using System;

namespace Healthware.Assist.Core.Logging
{
    public interface ILogger
    {
        void Informational(string formattedMessage, params object[] arguments);
        void Debug(string formattedMessage, params object[] arguments);
        void Thread(string formattedMessage, params object[] arguments);
        void Error(Exception error);
        void Error(Exception error, params string[] additionalInformation);
    }
}