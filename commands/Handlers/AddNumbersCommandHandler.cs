using System;
using commands.Messages;
using messaging.Contracts;

namespace commands.Handlers
{
    public class AddNumbersCommandHandler : IHandleCommand<AddNumbersCommand>
    {
        private readonly IArbiter _arbiter;

        public AddNumbersCommandHandler(IArbiter arbiter)
        {
            _arbiter = arbiter;
        }

        public void Handle(AddNumbersCommand command)
        {
            Console.WriteLine((int) (command.Number1 + command.Number2));

            _arbiter.Send(new MultiplyNumbers() { Number1 = command.Number1, Number2 = command.Number2 });
        }
    }
}