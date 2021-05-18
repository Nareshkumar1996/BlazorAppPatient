using System.Collections.Generic;

namespace Healthware.Assist.Core.Containers
{
    public interface IResolver
    {
        Dependency AnImplementationOf<Dependency>();
        IEnumerable<Dependency> AllImplementationsOf<Dependency>();
    }

    public class Resolver : IResolver
    {
        public Dependency AnImplementationOf<Dependency>()
        {
            return Resolve.AnImplementationOf<Dependency>();
        }

        public IEnumerable<Dependency> AllImplementationsOf<Dependency>()
        {
            return Resolve.AllImplementationsOf<Dependency>();
        }
    }
}