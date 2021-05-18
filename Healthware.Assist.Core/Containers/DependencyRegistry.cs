using System;
using System.Collections.Generic;
using System.Reflection;
using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Healthware.Assist.Core.Containers.Configurations;
using Healthware.Assist.Core.Extensions;

namespace Healthware.Assist.Core.Containers
{
    public interface IDependencyRegistry
    {
        Interface GetMeAnImplementationOf<Interface>();
        IEnumerable<Interface> GetMeAllTheImplementationsOf<Interface>();
        T GetMeAnImplementationOf<T>(string controllerName);
        void Release(object obj);
    }

    public class DependencyRegistry : IDependencyRegistry
    {
        readonly IWindsorContainer container;

        public DependencyRegistry() : this(new WindsorContainerFactory())
        {
        }

        public DependencyRegistry(IWindsorContainerFactory container_factory)
        {
            container = container_factory.Create();
        }

        public Interface GetMeAnImplementationOf<Interface>()
        {
            return container.Resolve<Interface>();
        }

        public object GetMeAnImplementationOf(Type theType)
        {
            return container.Resolve(theType);
        }

        public T GetMeAnImplementationOf<T>(string controllerName)
        {
            return container.Resolve<T>(controllerName);
        }

        public void Release(object obj)
        {
            container.Release(obj);
        }

        public IEnumerable<Interface> GetMeAllTheImplementationsOf<Interface>()
        {
            return container.ResolveAll<Interface>();
        }

        public void Singleton<Interface>(Interface implementation)
        {
            container.Register(Component.For(typeof(Interface)).Instance(implementation)
                .LifestyleSingleton().Named(CreateKeyFor(typeof(Interface), implementation.GetType())));
        }

        public void Singleton<Interface, Implementation>() where Implementation : Interface
        {
            register(typeof(Interface), typeof(Implementation), LifestyleType.Singleton);
        }

        public void ScopedSingleton<Interface, Implementation>() where Implementation : Interface
        {
            register(typeof(Interface), typeof(Implementation), LifestyleType.Scoped);
        }

        public void Transient<Interface, Implementation>() where Implementation : Interface
        {
            Transient(typeof(Interface), typeof(Implementation));
        }

        public void Transient(Type the_interface, Type implementation)
        {
            register(the_interface, implementation, LifestyleType.Transient);
        }

        public void Transient(Type the_interface, object implementation)
        {
            container.Register(Component.For(the_interface).Instance(implementation).Named(CreateKeyFor(the_interface, the_interface)).LifeStyle.Transient);
        }

        public void Transient(string key, Type implementation)
        {
            container.Register(Component.For(implementation).Named(key).LifeStyle.Transient);
        }

        public void PerThread<Interface, Implementation>() where Implementation : Interface
        {
            register(typeof(Interface), typeof(Implementation), LifestyleType.Thread);
        }

        public void PerWebRequest<Interface, Implementation>() where Implementation : Interface
        {
            var key = CreateKeyFor(typeof(Interface), typeof(Implementation));
            if (!container.Kernel.HasComponent(key))
            {
                container.Register(Component.For(typeof(Interface)).ImplementedBy(typeof(Implementation)).LifeStyle
                    .Scoped().Named(key));
            }
        }

        public void PerWebRequest(Type theInterface, Type implementation)
        {
            var key = CreateKeyFor(theInterface, implementation);
            if (!container.Kernel.HasComponent(key))
            {
                container.Register(Component.For(theInterface).ImplementedBy(implementation).LifeStyle
                    .Scoped().Named(key));
            }

        }

        void register(Type the_interface, Type implementation, LifestyleType type)
        {
            var key = CreateKeyFor(the_interface, implementation);
            if (!container.Kernel.HasComponent(key))
            {
                container.Register(Component.For(the_interface).ImplementedBy(implementation).LifeStyle.Is(type).Named(key));
            }
        }

        string CreateKeyFor<Interface, Implementation>()
        {
            return CreateKeyFor(typeof(Interface), typeof(Implementation));
        }

        string CreateKeyFor(Type the_interface, Type implementation)
        {
            return "{0}-{1}".FormatWith(the_interface.FullName, implementation.FullName);
        }

        public IEnumerable<Type> RetrieveAllTypes()
        {
            foreach (var handler in container.Kernel.GetAssignableHandlers(typeof(object)))
            {
                Type impl = handler.ComponentModel.Implementation;
                if (impl.IsAbstract || impl.IsGenericTypeDefinition)
                {
                    continue;
                }
                foreach (var service in handler.ComponentModel.Services)
                {
                    yield return service;
                }
            }
        }

        public void RegisterAllTypesBasedOn<T>()
        {
            container.Register(
                Classes.FromAssembly(typeof(T).Assembly)
                    .BasedOn<T>()
                    .WithService.AllInterfaces()
                );
        }

        public void RegisterAllTypesBasedOn(Type type)
        {
            container.Register(
                Classes.FromAssembly(type.Assembly)
                    .BasedOn(type)
                    .WithService.AllInterfaces().LifestyleTransient()
            );
        }

        public void RegisterAllTypesIn(Assembly assembly)
        {
            var configuration = new ComponentRegistrationConfiguration();

            container.Register(
                            Classes
                                .FromAssembly(assembly)
                                .Pick()
                                .WithService.FirstInterface()
                                .Configure(c => configuration.Configure(c))
                            );
        }

        public IWindsorContainer GetContainer()
        {
            return container;
        }
    }
}