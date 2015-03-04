using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassTransitExample.Messages
{
    public class BaseMessage
    {

        public BaseMessage()
        {
        }
        public int Retried { get; set; }
    }
}
