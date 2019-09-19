using messaging.Contracts;

namespace commands.Messages
{
    public class GetNumbersMultiplied : IRequest<long>
    {
        public int Number1 { get; set; }
        public int Number2 { get; set; }
    }
}