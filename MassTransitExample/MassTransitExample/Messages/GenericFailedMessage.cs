using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassTransitExample.Messages
{
    public class GenericFailedMessage<T> : BaseMessage
    {

        public T SourceMessage { get; set; }
        public SubmitOrderFailedMessage FailedMessage { get; set; }

    }
}
