using System;
using System.Linq;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Healthware.Assist.Core.Containers.Configurations;
using Healthware.Assist.Core.Utility;
using Healthware.Assist.Core.Utility.Ioc;

namespace Healthware.Assist.Core.Containers
{
    public interface IWindsorContainerFactory : IFactory<IWindsorContainer>
    {
    }

    public class WindsorContainerFactory : IWindsorContainerFactory
    {
        private static IWindsorContainer container;
        private static readonly object mutex = new object();
        private static bool is_initialized;

        public static void Uninitilize()
        {
            is_initialized = false;
        }


        private readonly ISpecification<Type> exclusion_specification;
        private readonly IConfiguration<ComponentRegistration> configuration;

        public WindsorContainerFactory(ISpecification<Type> exclusion_specification) : this(exclusion_specification, new ComponentRegistrationConfiguration())
        { }

        public WindsorContainerFactory() : this(new ComponentExclusionSpecification(), new ComponentRegistrationConfiguration())
        { }

        public WindsorContainerFactory(ISpecification<Type> exclusion_specification, IConfiguration<ComponentRegistration> configuration)
        {
            this.exclusion_specification = exclusion_specification;
            this.configuration = configuration;
        }

        public IWindsorContainer Create()
        {
            if (!is_initialized)
            {
                lock (mutex)
                {
                    if (!is_initialized)
                    {
                        container = new WindsorContainer();
                        container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel));
                        container.Kernel.Resolver.AddSubResolver(new ArrayResolver(container.Kernel));
                        container
                            .Register(
                                Classes.FromAssemblyContaining(typeof(IWindsorContainerFactory))
                                .Pick().WithServiceFirstInterface()
                                .Unless(
                                    (item) =>
                                    {



                                        var interfaces = item.GetInterfaces();

                                        if (item.IsDefined(typeof(DoNotRegisterInContainer), false))
                                            return true;

                                        if (!interfaces.Any())
                                            return true;
                                        
                                        //Ignore EC.Builder.Web.Navigation
                                   //     if (item.Namespace != null && item.Namespace.Contains(typeof(UrlBuilder).Namespace))
                                     //       return true;
                                        
                                        return exclusion_specification.IsSatisfiedBy(item);
                                    }
                                    )
                                .Configure(c => configuration.Configure(c))
                            );

                        /*container
                          .Register(
                              Classes.FromAssemblyContaining<ISyncOrganizationCommand>()
                                  .Pick()
                                  .WithServiceAllInterfaces()
                                  .Unless(exclusion_specification.IsSatisfiedBy)
                                  .Configure(c => configuration.Configure(c))
                          );*/
                        
                        is_initialized = true;
                    }
                }
            }
            return container;
        }
    }
}