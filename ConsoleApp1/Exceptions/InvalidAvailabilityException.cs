using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Exceptions
{
    internal class InvalidAvailabilityException : Exception
    {
        public InvalidAvailabilityException() { }

        public InvalidAvailabilityException(string message) { }

        public InvalidAvailabilityException(string message, Exception inner) : base(message, inner) { }
    }
}
