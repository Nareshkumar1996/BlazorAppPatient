using System;
using log4net;

namespace Healthware.Assist.Core.Logging
{
    public class Log4NetWithPrefixLogger : Log4NetLogger
    {
       // private ErrorLog elmahLog;
        public Log4NetWithPrefixLogger(ILog underlying_logger) : base(underlying_logger)
        {
         //   elmahLog = ErrorLog.GetDefault(null);
        }

        public override void Error(Exception error)
        {
            base.Error(error);
           // elmahLog.Log(new Error(error));
        }
    }
}
