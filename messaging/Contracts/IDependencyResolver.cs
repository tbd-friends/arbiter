using System;
using System.Runtime.InteropServices.ComTypes;

namespace messaging.Contracts
{
    public interface IDependencyResolver
    {
        object Resolve(Type instance);

    }
}