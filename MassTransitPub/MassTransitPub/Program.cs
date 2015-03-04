using MassTransit;
using MassTransitExample.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassTransitPub
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

            });
            _bus.Publish<SubmitOrder>(new SubmitOrderMessage());
            Console.Out.WriteLine("Submit Order Message Fired");
            Console.Read();
        }
    }
}
