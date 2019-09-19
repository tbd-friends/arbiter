using System;
using messaging.Contracts;

namespace messaging
{
    public class Arbiter : IArbiter
    {
        private readonly IDependencyResolver _resolver;
        private readonly IHandlerRegistry _registry;

        public Arbiter(IDependencyResolver resolver, IHandlerRegistry registry)
        {
            _resolver = resolver;
            _registry = registry;
        }

        public void Send<TCommand>(TCommand command) where TCommand : class
        {
            var handlerTypes = _registry.GetHandlerTypesFor<TCommand>();

            foreach (var handlerType in handlerTypes)
            {
                var handler = (IHandleCommand<TCommand>)_resolver.Resolve(handlerType);

                handler.Handle(command);
            }
        }

        public void Send<TCommand>(Action<TCommand> builder) where TCommand : class, new()
        {
            TCommand command = new TCommand();

            builder(command);

            Send(command);
        }
    }
}