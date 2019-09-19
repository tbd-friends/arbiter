using System;
using Autofac;
using messaging.Contracts;

namespace messaging.autofac
{
    public class AutoFacDependencyResolver : IDependencyResolver
    {
        private readonly IContainer _container;

        public AutoFacDependencyResolver(IContainer container)
        {
            _container = container;
        }

        public object Resolve(Type instance)
        {
            return _container.Resolve(instance);
        }
    }
}
