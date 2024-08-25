using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Exceptions
{
    internal class DeliveryTaskNotFoundException: Exception
    {
        public DeliveryTaskNotFoundException() { }

        public DeliveryTaskNotFoundException(string message) { }

        public DeliveryTaskNotFoundException(string message, Exception inner) : base(message, inner) { }
    }
}
