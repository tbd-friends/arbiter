using System;
using System.Diagnostics;
using System.Dynamic;
using System.Reflection;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using commands.Messages;
using Lamar;
using messaging;
using messaging.Contracts;
using messaging.lamar;

namespace test
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var container = new Container(cfg =>
            {
                cfg.For<IDependencyResolver>().Use<LamarDependencyResolver>();
                cfg.For<IHandlerRegistry>().Use(sc =>
                {
                    var result = new HandlerRegistry();

                    result.Register(typeof(AddNumbers).Assembly);

                    return result;
                });
                cfg.For<IArbiter>().Use<Arbiter>();
            });

            var arbiter = container.GetInstance<IArbiter>();

            Stopwatch sw = Stopwatch.StartNew();

            StringBuilder sb = new StringBuilder();

            await arbiter.Publish<AddNumbers>(a =>
            {
                a.Number1 = 1;
                a.Number2 = 2;
            });

            //for (int i = 0; i < 100000; i++)
            //{
            //    // Example, send a command
            //    arbiter.Send<AddNumbers>(c =>
            //    {
            //        c.Number1 = 2;
            //        c.Number2 = 2;
            //    });

            //    // Example, get an answer
            //    var answer = arbiter.Send<GetNumbersMultiplied, long>(c =>
            //    {
            //        c.Number1 = 10;
            //        c.Number2 = 20;
            //    });

            //    sb.Append(answer);
            //}

            sw.Stop();

            Console.WriteLine($"{sw.Elapsed}");
        }
    }
}
