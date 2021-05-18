using System.Diagnostics;
using Castle.DynamicProxy;

namespace Healthware.Assist.Core.Logging
{
    public interface ILoggingInterceptor : IInterceptor
    {
    }

    public class LoggingInterceptor : ILoggingInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            invocation.Proceed();
            stopwatch.Stop();
            this.Log().Debug("{0}.{1} took {2}", invocation.TargetType.Name, invocation.Method.Name, stopwatch.Elapsed);
        }
    }
}