using System.Linq;
using System.Reflection;
using System.Web.Http;
using Castle.Core;
using Castle.Windsor;
using Healthware.Assist.Core.Containers;
using Healthware.Assist.Core.Extensions;
using Healthware.Assist.Core.Utility;
using Healthware.Assist.Core.Utility.Routes;
using Healthware.Assist.Core.Web.Common.Validations;
using Healthware.Server.Controllers;
using Microsoft.AspNetCore.Authentication;

namespace Healthware.Server
{
    public class Ioc
    {
        public static IWindsorContainer WireupApi(DependencyRegistry registry)
        {
            WireUpUiLayer(registry);
            WireUpServiceLayer(registry);
            WireUpEfCoreLayer(registry);
            return registry.GetContainer();;
        }

        private static void WireUpUiLayer(DependencyRegistry registry)
        {
            WireupControllers(registry);
            //registry.PerWebRequest<IUrlBuilder, UrlBuilder>();
        }

        private static void WireupControllers(DependencyRegistry registry)
        {
            var controllers = typeof(Ioc).Assembly.GetTypes().Where(x => x.IsSubclassOf(typeof(ApiController)));
            controllers.Each(x => registry.Transient(x.Name, x));
            //WireupByInterfaceConvention(typeof(RegistrationController).Assembly, registry);
            WireupByInterfaceConvention(typeof(LoginController).Assembly, registry);
        }

        private static void WireUpServiceLayer(DependencyRegistry registry)
        {
            //WireupByInterfaceConvention(typeof(RegistrationService).Assembly, registry);
            WireupByInterfaceConvention(typeof(AuthenticationService).Assembly, registry);
        }
        
        private static void WireUpEfCoreLayer(DependencyRegistry registry)
        {
            //WireupByInterfaceConvention(typeof(PatientProfileRepository).Assembly, registry);
        }

        private static void WireupByInterfaceConvention(Assembly assembly, DependencyRegistry registry)
        {
            var allInterfaces = assembly.GetTypes().Where(x => x.IsInterface && x.Name.StartsWith("I"));
            var allTypes = assembly.GetTypes().Where(x => x.IsClass).ToList();

            var interfaceAndClassList = from theInterface in allInterfaces
                let classToLookFor = theInterface.Name.Substring(1)
                let theClass = allTypes.SingleOrDefault(x => x.Name.Equals(classToLookFor))
                let isPerWebRequest = theInterface.IsDefined(typeof(ScopedAttribute), true)
                where theClass != null
                select new {theInterface, theClass, isPerWebRequest};

            interfaceAndClassList.Each(x =>
                {
                    if (x.isPerWebRequest || x.theClass.Name.Equals("JwtHelper"))
                        registry.PerWebRequest(x.theInterface, x.theClass);
                    else
                        registry.Transient(x.theInterface, x.theClass);
                }
            );

            registry.RegisterAllTypesBasedOn(typeof(IValidator<>));
            //registry.RegisterAllTypesBasedOn(typeof(CCube.PatientPortal.Services.Registration.Validation.IValidator<>));
        }
    }
}