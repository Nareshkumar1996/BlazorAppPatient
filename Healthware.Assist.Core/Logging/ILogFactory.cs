using System;

namespace Healthware.Assist.Core.Logging
{
    public interface ILogFactory
    {
        ILogger CreateFor(Type type);
    }
}