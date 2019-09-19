using System.Dynamic;
using System.Reflection;
using System.Security;
using commands.Messages;
using Lamar;
using messaging;
using messaging.Contracts;
using messaging.lamar;

namespace test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var container = new Container(cfg =>
            {
                cfg.For<IDependencyResolver>().Use<LamarDependencyResolver>();
                cfg.For<IHandlerRegistry>().Use(sc =>
                {
                    var result = new HandlerRegistry();

                    result.Register(typeof(AddNumbersCommand).Assembly);

                    return result;
                });
                cfg.For<IArbiter>().Use<Arbiter>();
            });

            var arbiter = container.GetInstance<IArbiter>();


            // Example, send a command
            arbiter.Send<AddNumbersCommand>(c =>
            {
                c.Number1 = 2;
                c.Number2 = 2;
            });
        }
    }
}
