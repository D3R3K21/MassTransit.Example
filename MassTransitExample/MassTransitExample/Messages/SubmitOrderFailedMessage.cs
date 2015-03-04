using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassTransitExample.Messages
{
    public class SubmitOrderFailedMessage : BaseMessage
    {
        public string Message { get; set; }
    }
}
