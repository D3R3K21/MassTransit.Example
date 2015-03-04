using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassTransitExample.Messages
{
    public class SubmitOrderMessage : BaseMessage, SubmitOrder
    {

        public SubmitOrderMessage()
        {

            SubmitDate = DateTime.Now;
        }
        public Guid CorrelationId { get; set; }
        public DateTime SubmitDate { get; set; }
        public string CustomerNumber { get; set; }
        public string OrderNumber { get; set; }

    }
}
