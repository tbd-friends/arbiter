namespace messaging.Contracts
{
    public interface IHandleCommand<in TCommand> where TCommand : class
    {
        void Handle(TCommand command);
    }

}