using System;
using System.Collections.Generic;

namespace Healthware.Assist.Core.Containers
{
    public static class Resolve
    {
        public static IDependencyRegistry typeRegistry;

        public static void InitializeWith(IDependencyRegistry registry)
        {
            typeRegistry = registry;
        }

        public static Dependency AnImplementationOf<Dependency>()
        {
            try
            {
                return typeRegistry.GetMeAnImplementationOf<Dependency>();
            }
            catch (Exception e)
            {
                throw new InterfaceResolutionException(typeof (Dependency), e);
            }
        }

        public static IEnumerable<Dependency> AllImplementationsOf<Dependency>()
        {
            try
            {
                return typeRegistry.GetMeAllTheImplementationsOf<Dependency>();
            }
            catch (Exception e)
            {
                throw new InterfaceResolutionException(typeof(Dependency), e);
            }
        }

        public static T AnImplementationByKey<T>(string name)
        {
            return typeRegistry.GetMeAnImplementationOf<T>(name);
        }

        public static void Release(Object obj)
        {
            typeRegistry.Release(obj);
        }
    }
}