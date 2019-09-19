using System;
using System.Collections.Generic;
using System.Text;
using Lamar;
using messaging.Contracts;

namespace messaging.lamar
{
    public class LamarDependencyResolver : IDependencyResolver
    {
        private readonly IContainer _container;

        public LamarDependencyResolver(IContainer container)
        {
            _container = container;
        }

        public object Resolve(Type instance)
        {
            return _container.GetInstance(instance);
        }
    }
}
