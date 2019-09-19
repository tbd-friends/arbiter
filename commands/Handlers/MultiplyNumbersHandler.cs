using System;
using commands.Messages;
using messaging.Contracts;

namespace commands.Handlers
{
    public class MultiplyNumbersHandler : IHandleCommand<GetNumbersMultiplied, long>
    {
        public long Handle(GetNumbersMultiplied command)
        {
            return command.Number1 * command.Number2;
        }
    }
}