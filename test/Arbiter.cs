using System;

namespace test
{

    public interface IArbiter
    {
        void Send<TCommand>(TCommand command) where TCommand : class;
        void Send<TCommand>(Action<TCommand> builder) where TCommand : class, new();
    }

    public class Arbiter : IArbiter
    {
        public void Send<TCommand>(TCommand command) where TCommand : class
        {

        }

        public void Send<TCommand>(Action<TCommand> builder) where TCommand : class, new()
        {
            TCommand command = new TCommand();

            builder(command);


        }
    }
}