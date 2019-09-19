using System;
using commands.Messages;
using messaging.Contracts;

namespace commands.Handlers
{
    public class MultiplyNumbersHandler : IHandleCommand<MultiplyNumbers>
    {
        public void Handle(MultiplyNumbers command)
        {
            Console.WriteLine($"{command.Number1 * command.Number2} is the answer!");
        }
    }
}