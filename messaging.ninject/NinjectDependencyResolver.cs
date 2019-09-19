using System;
using messaging.Contracts;

namespace messaging.ninject
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        public NinjectDependencyResolver()
        {
            
        }

        public object Resolve(Type instance)
        {
            throw new NotImplementedException();
        }
    }
}