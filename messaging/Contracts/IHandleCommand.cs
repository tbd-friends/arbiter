namespace messaging.Contracts
{
    public interface IHandleCommand<in TCommand> 
        where TCommand : class, IRequest
    {
        void Handle(TCommand command);
    }

    public interface IHandleCommand<in TCommand, out TResult>
        where TCommand : class, IRequest<TResult>
    {
        TResult Handle(TCommand command);
    }
}