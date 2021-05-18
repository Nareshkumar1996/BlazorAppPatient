using Castle.MicroKernel.Registration;
using Microsoft.AspNetCore.Mvc;

namespace Healthware.Assist.Core.Containers.Configurations
{
    internal interface IControllerComponentConfiguration : IComponentRegistrationConfiguration
    {
    }

    internal class ControllerComponentConfiguration : IControllerComponentConfiguration
    {
        public void Configure(ComponentRegistration item)
        {
            if (typeof(ControllerBase).IsAssignableFrom(item.Implementation))
            {
                item.Named(item.Implementation.Name.ToLower());
            }
        }
    }
}