using System.Collections.Generic;
using Castle.Core;
using Castle.MicroKernel.Registration;
using Healthware.Assist.Core.Extensions;
using Healthware.Assist.Core.Utility;

namespace Healthware.Assist.Core.Containers.Configurations
{
    public interface IComponentRegistrationConfiguration : IConfiguration<ComponentRegistration>
    {
    }

    internal class ComponentRegistrationConfiguration : IComponentRegistrationConfiguration
    {
        readonly IList<IComponentRegistrationConfiguration> configurations;

        public ComponentRegistrationConfiguration()
            : this(
                new ControllerComponentConfiguration())
        //                new ReportComponentConfiguration())
        //                new LoggableComponentConfiguration())
        {
        }

        ComponentRegistrationConfiguration(params IComponentRegistrationConfiguration[] configurations)
        {
            this.configurations = configurations;
        }

        public void Configure(ComponentRegistration item)
        {
            this.configurations.Each(x => x.Configure(item));
            if (item.Implementation.GetCustomAttributes(typeof(SingletonAttribute), false).Length > 0)
            {
                item.LifeStyle.Is(LifestyleType.Singleton);
            }
            else if (item.Implementation.GetCustomAttributes(typeof(ScopedAttribute), false).Length > 0)
            {
                item.LifestyleScoped();
            }
            else
            {
                item.LifeStyle.Is(LifestyleType.Transient);
            }
        }
    }
}