using System;
using System.Collections.Generic;
using Healthware.Assist.Core.Utility;

namespace Healthware.Assist.Core.Containers
{
    public class ComponentExclusionSpecification : ISpecification<Type>
    {
        private IList<Type> excludedTypes;

        public ComponentExclusionSpecification()
        {
            excludedTypes = new List<Type>
            {
                typeof (DictionaryContext)
            };
        }

        public ComponentExclusionSpecification Add(Type type)
        {
            excludedTypes.Add(type);
            return this;
        }

        public bool IsSatisfiedBy(Type item)
        {
            return excludedTypes.Contains(item);
        }
    }
}