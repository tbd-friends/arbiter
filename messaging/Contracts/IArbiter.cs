using System;

namespace messaging.Contracts
{
    public interface IArbiter
    {
        void Send<TCommand>(TCommand command) where TCommand : class, IRequest;
        void Send<TCommand>(Action<TCommand> builder) where TCommand : class, IRequest, new();
        TResult Send<TCommand, TResult>(TCommand command) where TCommand : class, IRequest<TResult>;
        TResult Send<TCommand, TResult>(Action<TCommand> builder) where TCommand : class, IRequest<TResult>, new();
    }
}