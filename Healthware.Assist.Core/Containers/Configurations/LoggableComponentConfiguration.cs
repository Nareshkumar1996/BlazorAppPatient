using Castle.MicroKernel.Registration;
using Healthware.Assist.Core.Utility;

namespace Healthware.Assist.Core.Containers.Configurations
{
    internal interface ILoggableComponentConfiguration : IComponentRegistrationConfiguration
    {
    }

    internal class LoggableComponentConfiguration : ILoggableComponentConfiguration
    {
        public void Configure(ComponentRegistration item)
        {
            if (typeof(ILoggable).IsAssignableFrom(item.Implementation))
            {
                //item.Interceptors(new InterceptorReference(typeof(ILoggingInterceptor))).First.If((k, m) => true);
            }
        }
    }
}