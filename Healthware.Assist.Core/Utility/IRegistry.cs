using System.Collections.Generic;
using Healthware.Assist.Core.Containers;

namespace Healthware.Assist.Core.Utility
{
    public interface IRegistry<T>
    {
        IEnumerable<T> All();
    }

    public class DefaultRegistry<T> : IRegistry<T>
    {
        private readonly IDependencyRegistry registry;

        public DefaultRegistry(IDependencyRegistry registry)
        {
            this.registry = registry;
        }

        public IEnumerable<T> All()
        {
            return registry.GetMeAllTheImplementationsOf<T>();
        }
    }
}