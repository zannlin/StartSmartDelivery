using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Exceptions
{
    internal class InvalidDeliveryStatusException: Exception
    {
        public InvalidDeliveryStatusException() { }

        public InvalidDeliveryStatusException(string message) { Console.WriteLine(message); }

        public InvalidDeliveryStatusException(string message, Exception inner) : base(message, inner) { Console.WriteLine(message); }
    }
}
