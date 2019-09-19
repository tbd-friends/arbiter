using System;

namespace messaging.Contracts
{
    public interface IArbiter
    {
        void Send<TCommand>(TCommand command) where TCommand : class;
        void Send<TCommand>(Action<TCommand> builder) where TCommand : class, new();
    }
}