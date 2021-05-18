using System;
using System.Collections.Generic;
using System.Diagnostics;
using Castle.DynamicProxy;
using Healthware.Assist.Core.Containers;
using Healthware.Assist.Core.Extensions;
using Healthware.Assist.Core.Logging;
using Healthware.Assist.Core.Utility;

namespace Healthware.Assist.Core.Startup
{
    static public class Start
    {
        static public DependencyRegistry TheApplication(Action<DependencyRegistry> registerAdditionalComponents = null, Func<IEnumerable<Type>> additionalTypesToExclude = null)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var dependencyRegistry = WireupIOC(registerAdditionalComponents, additionalTypesToExclude);
            Resolve.InitializeWith(dependencyRegistry);
            stopwatch.Stop();

            new Object().Log().Informational("Start up time: {0}",stopwatch.Elapsed);
            return dependencyRegistry;
        }

        public static DependencyRegistry WireupIOC(Action<DependencyRegistry> registerAdditionalComponents = null, Func<IEnumerable<Type>> additionalTypesToExclude = null)
        {
            var componentExclusionSpecification = new ComponentExclusionSpecification();
            //componentExclusionSpecification.Add(typeof(Log4NetWithElmahLogger));
            
            additionalTypesToExclude?.Invoke()?.Each(x => componentExclusionSpecification.Add(x));

            var registry = new DependencyRegistry(new WindsorContainerFactory(componentExclusionSpecification));
            var proxyGenerator = new ProxyGenerator();
          /*  var termsInterceptor =
                proxyGenerator.CreateInterfaceProxyWithoutTarget(typeof(ITerms), new TermsInterceptor());*/
            
            registry.Singleton<IContext, DictionaryContext>();
            //registry.Singleton<IApiAuthProvider, ApiAuthProvider>();

            if (registerAdditionalComponents != null)
            {
                registerAdditionalComponents(registry);
            }

            return registry;
        }
    }

    static public class Stop
    {
        static public void TheApplication()
        {
            Resolve.InitializeWith(null);
        }
    }
}