using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Exceptions
{
    internal class DriverNotFoundException : Exception
    {
        public DriverNotFoundException() { }

        public DriverNotFoundException(string message) { }

        public DriverNotFoundException(string message, Exception inner) : base(message, inner) { }
    }
}
