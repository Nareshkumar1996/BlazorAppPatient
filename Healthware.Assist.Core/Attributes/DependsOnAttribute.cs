using System;

namespace Healthware.Assist.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class DependsOnAttribute : Attribute
    {
        /// <summary>Types of depended modules.</summary>
        public Type[] DependedModuleTypes { get; private set; }

        /// <summary>
        /// Used to define dependencies of an  module to other modules.
        /// </summary>
        /// <param name="dependedModuleTypes">Types of depended modules</param>
        public DependsOnAttribute(params Type[] dependedModuleTypes) => this.DependedModuleTypes = dependedModuleTypes;
    }
}
