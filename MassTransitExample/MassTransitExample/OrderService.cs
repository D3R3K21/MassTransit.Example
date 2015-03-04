using MassTransit;
using MassTransitExample.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassTransitExample
{
    public class OrderService
    {

        IServiceBus _bus;

        public void Start()
        {
            _bus = ServiceBusFactory.New(x =>
            {
                x.UseRabbitMq();
                x.ReceiveFrom("rabbitmq://localhost/learningmt_orderservice");
                x.Subscribe(sub => sub.Consumer<SubmitOrderConsumer>());
            });
            
        }

        public void Stop()
        {
            _bus.Dispose();
        }
    }
}
