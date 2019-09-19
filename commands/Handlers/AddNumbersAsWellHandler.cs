using System;
using commands.Messages;
using messaging.Contracts;

namespace commands.Handlers
{
    public class AddNumbersAsWellHandler : IHandleCommand<AddNumbers>
    {
        public void Handle(AddNumbers command)
        {
            Console.WriteLine($"{command.Number2 * 4 + command.Number1 + 10}");
        }
    }
}