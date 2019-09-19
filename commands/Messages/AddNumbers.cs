using messaging.Contracts;

namespace commands.Messages
{
    public class AddNumbers : IRequest
    {
        public int Number1 { get; set; }
        public int Number2 { get; set; }
    }
}