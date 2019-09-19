using System;
using System.Collections.Generic;
using System.Reflection;

namespace messaging.Contracts
{
    public interface IHandlerRegistry
    {
        void Register(Assembly assembly);
        IEnumerable<Type> GetHandlerTypesFor<TCommand>();
    }
}