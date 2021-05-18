using System;

namespace Healthware.Assist.Core.Containers
{
    public class InterfaceResolutionException : Exception
    {
        public InterfaceResolutionException(Type type, Exception exception) :base($"Attempted to resolve {type.FullName}",exception)
        {
        }
    }
}