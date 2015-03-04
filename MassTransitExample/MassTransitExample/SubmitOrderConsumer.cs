using MassTransit;
using MassTransitExample.Messages;
using System;
using System.Threading;

namespace MassTransitExample
{
    public class SubmitOrderConsumer :
        Consumes<SubmitOrderMessage>.Context,
        Consumes<SubmitOrderFailedMessage>.Context,
        Consumes<GenericFailedMessage<SubmitOrderMessage>>.Context
    {
        public void Consume(IConsumeContext<SubmitOrderMessage> context)
        {
            Console.Out.WriteLine("Submit Order Message Received");

            try
            {
                throw new Exception("Some Exception");

            }
            catch (Exception ex)
            {
                context.Respond(new GenericFailedMessage<SubmitOrderMessage>()
                {
                    Retried = context.Message.Retried + 1,
                    SourceMessage = context.Message,
                    FailedMessage = new SubmitOrderFailedMessage() { Message = ex.Message }

                });

            }
        }
        public void Consume(IConsumeContext<SubmitOrderFailedMessage> context)
        {
            Console.Out.WriteLine("Submit Order Failed Message Received");
            Console.Out.Write("Limit Reached And Typed Failed Message Fired");
        }
        public void Consume(IConsumeContext<GenericFailedMessage<SubmitOrderMessage>> context)
        {
            Console.Out.WriteLine("Generic Failed Message Received");
            Console.Out.WriteLine("Retry Number: " + context.Message.Retried);
            if (context.Message.Retried >= 3)
            {

                context.Respond(context.Message.FailedMessage);
            }
            else
            {
                Thread.Sleep(5 * 1000);
                context.Message.SourceMessage.Retried = context.Message.Retried;
                context.Respond(context.Message.SourceMessage);

            }

        }

    }
}
