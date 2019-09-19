using System;
using System.Diagnostics;
using commands.Messages;
using messaging.Contracts;

namespace commands.Handlers
{
    public class AddNumbersCommandHandler : IHandleCommand<AddNumbers>
    {
        private readonly IArbiter _arbiter;

        public AddNumbersCommandHandler(IArbiter arbiter)
        {
            _arbiter = arbiter;
        }

        public void Handle(AddNumbers command)
        {
            int answer = command.Number1 + command.Number2;
        }
    }
}