using MassTransit;
using MassTransitExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Startup
{
    class Program
    {
        

        static void Main(string[] args)
        {
            IServiceBus _bus;

            _bus = ServiceBusFactory.New(x =>
            {
                x.UseRabbitMq();
                x.ReceiveFrom("rabbitmq://localhost/learningmt_orderservice");
                x.Subscribe(sub => sub.Consumer<SubmitOrderConsumer>());
            });
            Console.Out.WriteLine("Service Started");
            Console.Read();
        }
    }
}
