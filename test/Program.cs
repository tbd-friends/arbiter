using System;
using System.Security;

namespace test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var arbiter = new Arbiter();

            arbiter.Send(new AddNumbersCommand()
            {
                Id = 1,
                Name = "Test",
                ActionDateTime = DateTime.UtcNow
            });

            arbiter.Send<AddNumbersCommand>(c =>
            {
                c.Id = 1;
                c.Name = "Test";
                c.ActionDateTime = DateTime.UnixEpoch;
            });

        }
    }

    public class AddNumbersCommand
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime ActionDateTime { get; set; }
    }

}
