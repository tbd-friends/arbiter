using System;
using System.Linq;
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

        public void Send<TCommand>(TCommand command)
            where TCommand : class, IRequest
        {
            var handlerTypes = _registry.GetHandlerTypesFor<TCommand>();

            foreach (var handlerType in handlerTypes)
            {
                var handler = (IHandleCommand<TCommand>)_resolver.Resolve(handlerType);

                handler.Handle(command);
            }
        }

        public TResult Send<TCommand, TResult>(TCommand command)
            where TCommand : class, IRequest<TResult>
        {
            var handlerType = _registry.GetHandlerTypesFor<TCommand, TResult>().First();

            var handler = (IHandleCommand<TCommand, TResult>)_resolver.Resolve(handlerType);

            return handler.Handle(command);
        }

        public void Send<TCommand>(Action<TCommand> builder)
            where TCommand : class, IRequest, new()
        {
            TCommand command = new TCommand();

            builder(command);

            Send(command);
        }

        public TResult Send<TCommand, TResult>(Action<TCommand> builder)
            where TCommand : class, IRequest<TResult>, new()
        {
            TCommand command = new TCommand();

            builder(command);

            return Send<TCommand, TResult>(command);
        }
    }
}